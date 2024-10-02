using Rado.SUA.Service;
using Rado.SUA.ViewModel;
using System.Windows;

namespace Rado.SUA.Windows.PopUp
{
    /// <summary>
    /// Interaction logic for ConfirmationWindow.xaml
    /// </summary>
    public partial class ConfirmationWindow : Window
    {
        private UpgradeOperationRepositoryViewModel newRepo;
        private int newIndex;
        public ConfirmationWindow(UpgradeOperationRepositoryViewModel repository, int index)
        {
            InitializeComponent();
            newRepo = repository;
            newIndex = index;
        }

        private void btn_no_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_yes_Click(object sender, RoutedEventArgs e)
        {
            var configureWindow = new ConfigureWindow();   
            if (configureWindow.listBox.SelectedIndex >= -1)
            {
                newRepo.SelectedOperation.SelectedPhase.Tasks.RemoveAt(newIndex);
            }
            Close();
        }
    }
}
