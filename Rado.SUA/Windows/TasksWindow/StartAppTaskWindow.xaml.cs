using Rado.SUA.ViewModel;
using Rado.SUA.ViewModel.Definition;
using System.Windows;

namespace Rado.SUA.Windows.TasksWindow
{
    /// <summary>
    /// Interaction logic for StartAppTaskWindow.xaml
    /// </summary>
    public partial class StartAppTaskWindow : TaskWindow
    {
        public StartAppTaskWindow(StartAppTaskDefinitionViewModel definition)
        {
            InitializeComponent();
            var task = DataContext as StartAppTaskViewModel;
            task.Label = definition.Label;
            task.Definition = definition;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as StartAppTaskViewModel;
            task.Name = appNameTxtBox.Text;            
            task.Description = textDescription.Text;
            if (task.Name == "")
            {
                MessageBox.Show("Name does not have value");
            }
            else
            {
                AddOrEditTask(task);
                Close();               
            }
            
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as StartAppTaskViewModel;
            task.Cancel(_orginalTask);
            Close();
        }
    }
}
