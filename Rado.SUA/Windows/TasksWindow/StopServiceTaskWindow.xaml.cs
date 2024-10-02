using Rado.SUA.ViewModel;
using Rado.SUA.ViewModel.Definition;
using System.Windows;

namespace Rado.SUA.Windows.TasksWindow
{
    /// <summary>
    /// Interaction logic for StopServiceTaskWindow.xaml
    /// </summary>
    public partial class StopServiceTaskWindow : TaskWindow
    {
        public StopServiceTaskWindow(StopServiceTaskDefinitionViewModel definition)
        {
            InitializeComponent();
            var task = DataContext as StopServiceTaskViewModel;
            task.Label = definition.Label;
            task.Definition = definition;
        }

        private void saveServicesBtn_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as StopServiceTaskViewModel;
            task.Description = textDescription.Text;
            if (task.Services.Count == 0)
            {
                MessageBox.Show("Service collection equals 0");
            }
            else
            {
                AddOrEditTask(task);
                Close();
            }  
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            var task = DataContext as StopServiceTaskViewModel;
            task.Cancel(_orginalTask);
            Close();
        }

        private void addServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            var service = DataContext as StopServiceTaskViewModel;
            if (serviceTxtBox.Text.Length > 0)
            {
                var serviceName = serviceTxtBox.Text;
                service.Services.Add(serviceName);
            }
            else
            {
                MessageBox.Show("You can not add empty element to the list.");
            } 
        }

        private void deleteServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            var service = DataContext as StartServiceTaskViewModel;
            int index = listBox.SelectedIndex;
            if (listBox.SelectedIndex >= 0)
            {
                service.Services.RemoveAt(index);
            }
        }
    }
}
