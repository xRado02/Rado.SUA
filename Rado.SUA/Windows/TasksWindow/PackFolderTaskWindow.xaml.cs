using Rado.SUA.ViewModel;
using Rado.SUA.ViewModel.Definition;
using System;
using System.IO;
using System.Windows;

namespace Rado.SUA.Windows.TasksWindow
{
    /// <summary>
    /// Interaction logic for PackFilesTaskWindow.xaml
    /// </summary>
    public partial class PackFolderTaskWindow : TaskWindow
    {
        
        public PackFolderTaskWindow(PackFolderTaskDefinitionViewModel definition)
        {
            InitializeComponent();
            var task = DataContext as PackFolderTaskViewModel;
            task.Label = definition.Label;
            task.Definition = definition;
        }

        private void btn_browse_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as PackFolderTaskViewModel;            
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
                task.Folder = folder;
            }
        }
        private void btn_saveAll_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as PackFolderTaskViewModel;
            task.Name = txt_name.Text;
            task.Description = textDescription.Text;
            if (task.Folder == null || task.Name == "")
            {
                MessageBox.Show("Main data equals null.");
            }
            else
            {
                AddOrEditTask(task);
                Close();
            }
            
        }
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as PackFolderTaskViewModel;
            task.Cancel(_orginalTask);
            Close();
        }
        
    }
}
