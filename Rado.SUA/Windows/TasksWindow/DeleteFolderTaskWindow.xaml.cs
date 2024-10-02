using Rado.SUA.ViewModel;
using Rado.SUA.ViewModel.Definition;
using System;
using System.IO;
using System.Windows;

namespace Rado.SUA.Windows.TasksWindow
{
    /// <summary>
    /// Interaction logic for DeleteFoldertTaskWindow.xaml
    /// </summary>
    public partial class DeleteFoldertTaskWindow : TaskWindow
    {
        public DeleteFoldertTaskWindow(DeleteFolderTaskDefinitionViewModel definition)
        {
            InitializeComponent();
            var task = DataContext as DeleteFolderTaskViewModel;
            task.Label = definition.Label;
            task.Definition = definition;

        }

        private void browseFolders_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as DeleteFolderTaskViewModel;
            var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();            
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                task.FoldersToDelete.Add(folderBrowserDialog.SelectedPath);
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {            
            var task = DataContext as DeleteFolderTaskViewModel;
            task.Description = textDescription.Text;
            if (task.FoldersToDelete.Count == 0)
            {
                MessageBox.Show("Folders collection equals 0");
            }
            else
            {
                AddOrEditTask(task);
                Close();
            }
            
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as DeleteFolderTaskViewModel;
            task.Cancel(_orginalTask);
            Close();
        }

        private void btn_deleteFiles_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as DeleteFolderTaskViewModel;
            var index = listBox.SelectedIndex;
            if (listBox.SelectedIndex >= 0)
            {
                task.FoldersToDelete.RemoveAt(index);
            }
        }
    }
}
