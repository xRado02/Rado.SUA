using Rado.SUA.ViewModel;
using Rado.SUA.ViewModel.Definition;
using System;
using System.IO;
using System.Windows;
using Rado.SUA.Windows.TasksWindow;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Rado.SUA.Logic;
using System.Linq;

namespace Rado.SUA.Windows.PopUp
{
    /// <summary>
    /// Interaction logic for EditPathWindow.xaml
    /// </summary>    
    public partial class EditPathWindow : Window
    {
        private int _selectedIndex;
        private WorkingOnFilesTaskViewModel _workingOnFilesTaskViewModel;        
        public EditPathWindow(WorkingOnFilesTaskViewModel workingOnFilesTaskViewModel, int index)
        {            
            InitializeComponent();
            var task = DataContext as WorkingOnFilesTaskViewModel;
            _workingOnFilesTaskViewModel = workingOnFilesTaskViewModel;
            task.PathToEdit = workingOnFilesTaskViewModel.PathToEdit;
            _selectedIndex = index;            
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {            
            _workingOnFilesTaskViewModel.PathToEdit = txtBox.Text;
            _workingOnFilesTaskViewModel.Files.RemoveAt(_selectedIndex);
            _workingOnFilesTaskViewModel.Files.Insert(_selectedIndex, _workingOnFilesTaskViewModel.PathToEdit);    
            Close();

        }
         
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
