using Rado.SUA.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace Rado.SUA.Windows
{
    /// <summary>
    /// Interaction logic for AddListWindow.xaml
    /// </summary>
    public partial class AddListWindow : Window
    {
        #region Fields

        private UpgradeOperationRepositoryViewModel _repository;

        #endregion

        #region Methods
        public AddListWindow(UpgradeOperationRepositoryViewModel repository)
        {
            _repository = repository;
            InitializeComponent();
        }
        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {            
            var operation = DataContext as UpgradeOperationViewModel;
            var newOperation = new UpgradeOperationViewModel();
            var configWindow = new ConfigureWindow();
            newOperation.Name = operation.Name;
            if (newOperation.Name != null)
            {
                _repository.AddOperation(newOperation);                
                Close();
            }
            else
            {
                MessageBox.Show("Name must has at least one character.");
            }         
        }
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
    }
}
