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
    /// Interaction logic for EditPathWindow2.xaml
    /// </summary>
    public partial class EditPathWindow2 : Window
    {
        private int _selectedIndex;
        private CopyFolderTaskViewModel _copyFolderTaskViewModel;
        public EditPathWindow2(CopyFolderTaskViewModel copyFolderTaskViewModel, int index)
        {
            InitializeComponent();
            var task = DataContext as CopyFolderTaskViewModel;
            _copyFolderTaskViewModel = copyFolderTaskViewModel;
            task.PathToEdit = copyFolderTaskViewModel.PathToEdit;
            _selectedIndex = index;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            _copyFolderTaskViewModel.PathToEdit = txtBox.Text;
            _copyFolderTaskViewModel.FoldersToCopy.RemoveAt(_selectedIndex);
            _copyFolderTaskViewModel.FoldersToCopy.Insert(_selectedIndex, _copyFolderTaskViewModel.PathToEdit);
            Close();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
