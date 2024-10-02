using Rado.SUA.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace Rado.SUA.Windows.TasksWindow
{
    public class TaskWindow : Window
    {
        protected UpgradeOperationPhaseViewModel _selectedPhase;
        protected UpgradeOperationTaskViewModel _orginalTask;
        public void Show(UpgradeOperationPhaseViewModel selectedPhase)
        {
            var task = DataContext as UpgradeOperationTaskViewModel;
            _orginalTask = task.Clone();            
            _selectedPhase = selectedPhase;            
            base.ShowDialog();
        }     

        public void Show(string path)
        {
            base.ShowDialog();
        }
        public virtual void AddOrEditTask(UpgradeOperationTaskViewModel task)
        {
            var index = _selectedPhase.Tasks.IndexOf(task);
            if (index == -1)
            {
                _selectedPhase.Tasks.Add(task);
            }
            else
            {
                _selectedPhase.Tasks.Insert(index, task);
                _selectedPhase.Tasks.RemoveAt(index + 1);
            }
        }
    }
}