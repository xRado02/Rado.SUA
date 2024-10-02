using Rado.SUA.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace Rado.SUA.Windows
{
    /// <summary>
    /// Interaction logic for AddPhaseWindow.xaml
    /// </summary>
    public partial class AddPhaseWindow : Window
    {

        #region Fields

        private UpgradeOperationViewModel _upgradeOperation;

        #endregion

        #region Methods
        public AddPhaseWindow(UpgradeOperationViewModel upgradeOperation)
        {
            _upgradeOperation = upgradeOperation;
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            var operationPhase = DataContext as UpgradeOperationPhaseViewModel;
            var newOperationPhase = new UpgradeOperationPhaseViewModel();
            newOperationPhase.Name = operationPhase.Name;  
            if (newOperationPhase.Name != null)
            {
                _upgradeOperation.AddPhase(newOperationPhase);
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
