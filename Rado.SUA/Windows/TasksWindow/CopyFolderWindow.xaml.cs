using Rado.SUA.ViewModel;
using Rado.SUA.ViewModel.Definition;
using Rado.SUA.Windows.PopUp;
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
using System.Windows.Shapes;

namespace Rado.SUA.Windows.TasksWindow
{
    /// <summary>
    /// Interaction logic for CopyFolderWindow.xaml
    /// </summary>
    public partial class CopyFolderWindow : TaskWindow
    {
        private bool saveButtonClicked = false;
        public CopyFolderWindow(CopyFolderTaskDefinitionViewModel definition)
        {
            InitializeComponent();
            var task = DataContext as CopyFolderTaskViewModel;
            task.Label = definition.Label;
            task.Definition = definition;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            saveButtonClicked = false;
            var task = DataContext as CopyFolderTaskViewModel;
            task.Cancel(_orginalTask);
            Close();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as CopyFolderTaskViewModel;
            task.Description = textDescription.Text;
            if (task.FoldersToCopy.Count == 0)
            {
                MessageBox.Show("Folders collection equals 0");
            }
            else
            {
                AddOrEditTask(task);
                Close();
            }
        }

        private void btn_browseTo_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as CopyFolderTaskViewModel;
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

        private void btn_browseFrom_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as CopyFolderTaskViewModel;
            var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                task.FoldersToCopy.Add(folderBrowserDialog.SelectedPath);
            }
        }

        private void btn_deleteFiles_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as CopyFolderTaskViewModel;
            var index = listBox.SelectedIndex;
            if (listBox.SelectedIndex >= 0)
            {
                task.FoldersToCopy.RemoveAt(index);
            }
        }

        private void btn_edti_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var task = DataContext as CopyFolderTaskViewModel;
                var index = listBox.SelectedIndex;
                task.PathToEdit = task.FoldersToCopy[index];
                var editWindow = new EditPathWindow2(task, index);
                editWindow.Show();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Choose the appropriate path.");
            }
        }
    }

        
    
}
