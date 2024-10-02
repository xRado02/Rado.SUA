using System.Windows;
using Rado.SUA.Logic;
using Rado.SUA.Service;
using Rado.SUA.ViewModel;
using Rado.SUA.Windows.PopUp;
using System;
using System.Threading.Tasks;
using System.Threading;
using Rado.SUA.Windows.TasksWindow;
using System.Collections.Generic;
using System.Linq;
using Rado.SUA.Exceptions;
using System.IO;

namespace Rado.SUA.Windows
{
    /// <summary>
    /// Interaction logic for UpgradeProcessWindow.xaml
    /// </summary>
    public partial class UpgradeProcessWindow : Window
    {
        public string repositoryPath = "repository.xml";
        UpgradeOperationRepositoryViewModel repositoryViewModel = new UpgradeOperationRepositoryViewModel();  
        LoadingBarPopUp loadingWindow1 = new LoadingBarPopUp();
        public UpgradeProcessWindow()
        {           
            InitializeComponent();
            var upgradeOperationUploadService = new UpgradeOperationUploadService();            
            repositoryViewModel = upgradeOperationUploadService.UploadFiles(repositoryPath);            
            DataContext = repositoryViewModel;
        }

        private async void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var upgradeOperationConverter = new UpgradeOperationRepositoryConverter();
                var repository = upgradeOperationConverter.ConvertToModel(repositoryViewModel);
                var selectedPhase = FindPhase(repository, repositoryViewModel.SelectedOperation.SelectedPhase.Id);                
                var currentVersion = txtBoxCurrentVersion.Text;
                var targetVersion = txtBoxTargetVersion.Text;              
                var placeholders = new List<PlaceholderData>();
                var environment = comboBox.SelectedItem.ToString();
                var extendedEnvironment = comboBox2.SelectedItem.ToString();                
                placeholders.Add(new PlaceholderData(PlaceholderCode.CurrentVersion, currentVersion));
                placeholders.Add(new PlaceholderData(PlaceholderCode.TargetVersion, targetVersion));
                placeholders.Add(new PlaceholderData(PlaceholderCode.Environment, GetEnvironmentValue(environment)));
                placeholders.Add(new PlaceholderData(PlaceholderCode.ExtendedEnvironment, GetExtendedEnvironmentValue(extendedEnvironment)));

                if (selectedPhase.Tasks.Count == 0)
                {
                    MessageBox.Show("There is no task in phase"); 
                }
                else
                {
                    loadingWindow1.Show();
                    await ExecuteAsync(selectedPhase, placeholders);
                }
               
                loadingWindow1.Close();
            }           
            catch (Exception ex  /*MyException ex*/)
            {
                loadingWindow1.Close();
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public async Task ExecuteAsync(UpgradeOperationPhase selectedPhase, List<PlaceholderData> placeholders)
        {
            try
            {
                var indexString = txtBoxIndex.Text;
                var resultOfParse = int.TryParse(indexString, out int index);
                if (resultOfParse == false)
                {
                    throw new ArgumentException("Invalid index");
                }
                else
                {
                    foreach (var task in selectedPhase.Tasks)
                    {
                        loadingWindow1.taskName.Text = $"Executing task: {task.Label}";
                        await Task.Run(() => task.Execute(placeholders, index));
                        await Task.Run(() => Task.Delay(3000));
                    }
                    loadingWindow1.Close();
                }
            }
            catch (FileNotFoundException ex2)
            {
                MessageBox.Show(ex2.ToString());
            }
            catch (ArgumentException ex)
            {
                loadingWindow1.Close();
                MessageBox.Show(ex.Message);
            }            
            MessageBox.Show("Process completed");
            
            
        }

        public UpgradeOperationPhase FindPhase(UpgradeOperationRepository repository, Guid selectedPhaseId)
        {
            foreach(var operation in repository.Operations)
            {
                foreach(var phase in operation.Phases)
                {
                    if(phase.Id == selectedPhaseId)
                    {
                        return phase;
                    }                    
                }
            }
            return null;            
        }

        private string GetEnvironmentValue(string environment)
        {
            if (environment == "PRODUCTION")
            {
                return "";
            }
            else
            {
                return "-" + environment;
            }
        }

        private string GetExtendedEnvironmentValue(string extendedEnvironment)
        {
            if (extendedEnvironment == "PRODUCTION")
            {
                return "Production";
            }
            else
            {
                return extendedEnvironment;
            }

        }
      
    }
}
