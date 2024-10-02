using Rado.SUA.ViewModel;
using System.Windows;
using Rado.SUA.Service;
using Rado.SUA.Windows.PopUp;
using Rado.SUA.Windows.TasksWindow;
using Rado.SUA.Logic;
using System;
using System.Windows.Input;
using Rado.SUA.ViewModel.Definition;

namespace Rado.SUA.Windows
{
    /// <summary>
    /// Interaction logic for ConfigureWindow.xaml
    /// </summary>
    public partial class ConfigureWindow : Window
    {
        public string repositoryPath = "repository.xml";
        public ConfigureWindow()
        {  
            InitializeComponent();
            var upgradeOperationUploadService = new UpgradeOperationUploadService();
            var repositoryViewModel = upgradeOperationUploadService.UploadFiles(repositoryPath);
            if (repositoryViewModel != null)
            { 
                DataContext = repositoryViewModel; 
            }
            
        }

        private void Button_Click_AddList(object sender, RoutedEventArgs e)
        {
            var repository = DataContext as UpgradeOperationRepositoryViewModel;
            AddListWindow addListWindow = new AddListWindow(repository);  
            addListWindow.ShowDialog();
            comboBoxOperations.SelectedIndex = 0;
        }
        
        private void Button_Click_AddPhase(object sender, RoutedEventArgs e)
        {            
            var repository = DataContext as UpgradeOperationRepositoryViewModel;
            AddPhaseWindow addPhaseWindow = new AddPhaseWindow(repository.SelectedOperation);
            if (repository.Operations.Count == 0)
            {
                MessageBox.Show("There is no operations, you can't add phase. First, create an operation.");
            }
            else
            {
                addPhaseWindow.ShowDialog();
            }            
            comboBoxPhase.SelectedIndex = 0;
        }
       
        private void Button_Click_AddTask(object sender, RoutedEventArgs e)
        {
            try
            {
                var repository = DataContext as UpgradeOperationRepositoryViewModel;
                if (repository == null || repository.SelectedOperation == null)
                {
                    MessageBox.Show("There is no operations, you can't add phase. First, create an operation.");                   
                }
                else if (repository.SelectedOperation.SelectedPhase == null)
                {
                    MessageBox.Show("There are no phases, you can't add a task. First, create a phase.");
                }
                else
                {

                    AddTaskWindow addTaskWindow = new AddTaskWindow(repository.SelectedOperation.SelectedPhase);
                    addTaskWindow.Owner = this;
                    addTaskWindow.ShowDialog();
                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There are no phases, you can't add a task. First, create a phase.");                
            }

        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();                      
        }
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            var repository = DataContext as UpgradeOperationRepositoryViewModel;
            var repositoryConverter = new UpgradeOperationRepositoryConverter();            
            var domainRepository = repositoryConverter.ConvertToModel(repository);
            var repositoryService = new UpgradeOperationRepositoryService(repositoryPath);
            repositoryService.SaveDataRepository(domainRepository);
            Close();            
        }
        private void btn_deleteTask_Click(object sender, RoutedEventArgs e)
        {
            var repository = DataContext as UpgradeOperationRepositoryViewModel;
            var index = listBox.SelectedIndex;
            var confirmWindow = new ConfirmationWindow(repository, index);
            if (index > -1)
            {
                confirmWindow.ShowDialog();
            }
        }

        private void btn_editTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var repository = DataContext as UpgradeOperationRepositoryViewModel;
                var index = listBox.SelectedIndex;
                var taskToEdit = repository.SelectedOperation.SelectedPhase.Tasks[index];       
                var taskDefinition = taskToEdit.Definition as OperationTaskDefinitionViewModel;
                var viewWindow = taskDefinition.CreateWindow();
                viewWindow.DataContext = taskToEdit;
                viewWindow.Show(repository.SelectedOperation.SelectedPhase);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Choose the appropriate task.");
            }
            
        }

        private void btn_goDown(object sender, RoutedEventArgs e)
        {
            try
            {
                var repository = DataContext as UpgradeOperationRepositoryViewModel;
                var index = listBox.SelectedIndex;
                if (index != -1)
                {
                    var newIndex = index + 1;
                    if (newIndex < repository.SelectedOperation.SelectedPhase.Tasks.Count)
                    {
                        MoveTask(repository, index, newIndex);                        
                    }
                    
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Can't move task to index does not exist.");
            }

        }
        private void btn_goUp(object sender, RoutedEventArgs e)
        {
            try
            {
                var repository = DataContext as UpgradeOperationRepositoryViewModel;
                var index = listBox.SelectedIndex;
                if (index != -1 && index != 0)
                {
                    var newIndex = index - 1;
                    if (newIndex >= 0)
                    {
                        MoveTask(repository,index,newIndex);                        
                    }
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Can't move task to index does not exist.");
            }
        }
        private void MoveTask(UpgradeOperationRepositoryViewModel repository, int index, int newIndex)
        {
            var taskToMove = repository.SelectedOperation.SelectedPhase.Tasks[index];
            repository.SelectedOperation.SelectedPhase.Tasks.RemoveAt(index);
            repository.SelectedOperation.SelectedPhase.Tasks.Insert(newIndex, taskToMove);
            listBox.SelectedIndex = newIndex;
        }
    }
}
