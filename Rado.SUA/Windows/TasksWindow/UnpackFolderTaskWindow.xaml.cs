using System;
using System.Collections.Generic;
using System.Linq;
using Rado.SUA.ViewModel;
using Rado.SUA.ViewModel.Definition;
using System.IO;
using System.Windows;

namespace Rado.SUA.Windows.TasksWindow
{
    /// <summary>
    /// Interaction logic for UnpackFolderTaskWindow.xaml
    /// </summary>
    public partial class UnpackFolderTaskWindow : TaskWindow
    {
        public UnpackFolderTaskWindow(UnpackFolderTaskDefinitionViewModel definition)
        {
            InitializeComponent();
            var task = DataContext as UnpackFolderTaskViewModel;
            task.Label = definition.Label;
            task.Definition = definition;
        }

        private void btn_saveAll_Click(object sender, RoutedEventArgs e)
        {
            
            var task = DataContext as UnpackFolderTaskViewModel;
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
            var task = DataContext as UnpackFolderTaskViewModel;
            task.Cancel(_orginalTask);
            Close();
        }

        private void btn_browse_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as UnpackFolderTaskViewModel;
            var openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {      
               task.Folder = Path.GetFullPath(openFileDialog.FileName);                
            }
        }
    }
}
