using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Rado.SUA.ViewModel.Definition;
using System.Windows.Shapes;
using Rado.SUA.ViewModel;

namespace Rado.SUA.Windows.TasksWindow
{
    /// <summary>
    /// Interaction logic for FileFinderAndZipTaskWindow.xaml
    /// </summary>
    public partial class FileFinderAndZipTaskWindow : TaskWindow
    {
        public FileFinderAndZipTaskWindow(FindAndZipFileTaskDefinitionViewModel definition)
        {
            InitializeComponent();
            var task = DataContext as FindAndZipFileTaskVIewModel;
            task.Label = definition.Label;
            task.Definition = definition;
        }

        private void btn_browse_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as FindAndZipFileTaskVIewModel;
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
            var task = DataContext as FindAndZipFileTaskVIewModel;            
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
            var task = DataContext as FindAndZipFileTaskVIewModel;
            task.Cancel(_orginalTask);
            Close();
        }      
    }
}
