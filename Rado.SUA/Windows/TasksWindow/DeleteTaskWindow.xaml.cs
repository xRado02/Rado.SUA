using Rado.SUA.ViewModel;
using Rado.SUA.ViewModel.Definition;
using Rado.SUA.Windows.PopUp;
using System;
using System.IO;
using System.Windows;

namespace Rado.SUA.Windows.TasksWindow
{
    /// <summary>
    /// Interaction logic for DeleteTaskWindow.xaml
    /// </summary>
    public partial class DeleteTaskWindow : TaskWindow
    {
        public DeleteTaskWindow(DeleteFileTaskDefinitionViewModel definition)
        {
            InitializeComponent();
            var task = DataContext as DeleteFileTaskViewModel;
            task.Label = definition.Label;
            task.Definition = definition;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as DeleteFileTaskViewModel;
            task.Cancel(_orginalTask);
            Close();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {            
            var task = DataContext as DeleteFileTaskViewModel;
            task.Description = textDescription.Text;
            if (task.Files.Count == 0)
            {
                MessageBox.Show("Files collection equals 0");
            }
            else
            {
                AddOrEditTask(task);
                Close();
            }
            
        }

        private void browseFiles_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as DeleteFileTaskViewModel;
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

        private void btn_deleteFiles_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as DeleteFileTaskViewModel;
            var index = listBox.SelectedIndex;
            if (listBox.SelectedIndex >= 0)
            {
                task.Files.RemoveAt(index);
            }
        }

        private void editPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var task = DataContext as DeleteFileTaskViewModel ;
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
