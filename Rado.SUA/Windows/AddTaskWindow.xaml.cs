using Rado.SUA.ViewModel.Definition;
using System.Windows;
using Rado.SUA.ViewModel;
using System.Linq;

namespace Rado.SUA.Windows
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        private UpgradeOperationPhaseViewModel _selectedPhase;

        public AddTaskWindow(UpgradeOperationPhaseViewModel selectedPhase)
        {
            _selectedPhase = selectedPhase;
            InitializeComponent();
            DataContext = UpgradeTaskDefinitionRepositoryViewModel.Singleton;
        }

        private void choose_btn_Click(object sender, RoutedEventArgs e)
        {
            var definition = UpgradeTaskDefinitionRepositoryViewModel.Singleton.Definitions.FirstOrDefault(d => d.Type == (TaskType)task_cmbBox.SelectedIndex); 
            var viewWindow = definition.CreateWindow();
            viewWindow.Show(_selectedPhase);
            var addTaskWindow = new AddTaskWindow(_selectedPhase);
            addTaskWindow.Owner = this;
            Close();
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();            
        }      
    }
}