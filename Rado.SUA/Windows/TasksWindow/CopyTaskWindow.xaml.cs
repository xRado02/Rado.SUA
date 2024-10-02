using Rado.SUA.ViewModel;
using Rado.SUA.ViewModel.Definition;
using System;
using System.IO;
using System.Windows;
using Rado.SUA.Windows.PopUp;

namespace Rado.SUA.Windows.TasksWindow
{
    /// <summary>
    /// Interaction logic for CopyTaskWindow.xaml
    /// </summary>
    public partial class CopyTaskWindow : TaskWindow
    {
        private bool saveButtonClicked = false;
        public CopyTaskWindow(CopyFileTaskDefinitionViewModel definition)
        {
            InitializeComponent();
            var task = DataContext as CopyFileTaskViewModel;
            task.Label = definition.Label;            
            task.Definition = definition;            
        }
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            saveButtonClicked = false;
            var task = DataContext as CopyFileTaskViewModel;
            task.Cancel(_orginalTask);
            Close();  
        }
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {            
            var task = DataContext as CopyFileTaskViewModel;
            task.Description = textDescription.Text;
            saveButtonClicked = true;
            if (task.CopyTo == null || task.Files.Count == 0)
            {
                MessageBox.Show("Main data equals null.");
            }
            else
            {
                AddOrEditTask(task);             
                Close();
            }            
        }

        private void btn_browseFrom_Click(object sender, RoutedEventArgs e)
        {            
            var task = DataContext as CopyFileTaskViewModel;           
            var openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Multiselect = true;           
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);           
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {       
                foreach (string filename in openFileDialog.FileNames)
                {
                     task.Files.Add(Path.GetFullPath(filename));
                }          
            }              
        }
        private void btn_browseTo_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as CopyFileTaskViewModel;
            using var dialog = new System.Windows.Forms.FolderBrowserDialog
            {                
                Description = "Time to select a folder",
                UseDescriptionForTitle = true,
                SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + '/',
                ShowNewFolderButton = true
            };

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var folder = dialog.SelectedPath;                
                task.CopyTo = folder;
            }
        }
        private void btn_deleteFiles_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as CopyFileTaskViewModel;
            var index = listBox.SelectedIndex;
            if (listBox.SelectedIndex >= 0)
            {                
                task.Files.RemoveAt(index);
            }
        }
        private void TaskWindow_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var task = DataContext as CopyFileTaskViewModel;
            if (saveButtonClicked == false)
            {
                task.Cancel(_orginalTask);               
            }          
        }

        private void btn_edti_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var task = DataContext as CopyFileTaskViewModel;
                var index = listBox.SelectedIndex;
                task.PathToEdit = task.Files[index];
                var editWindow = new EditPathWindow(task, index);
                editWindow.Show();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Choose the appropriate path.");
            }
            
        }
       
    }
      
}
