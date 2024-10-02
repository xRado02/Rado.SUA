using Rado.SUA.ViewModel.MyBase;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Rado.SUA.ViewModel

{
    public class UpgradeOperationPhaseViewModel : MyBaseViewModel
    {
        #region Fields        
        private UpgradeOperationTaskViewModel _selectedTask;
        #endregion
        
        public UpgradeOperationPhaseViewModel()
        {
            Tasks = new ObservableCollection<UpgradeOperationTaskViewModel>();
        }
        
        #region Properties
        public string Name { get; set; }  
        public Guid Id { get; set; }
        public ObservableCollection<UpgradeOperationTaskViewModel> Tasks { get; }
        public UpgradeOperationTaskViewModel SelectedTask
        {
            get
            {
                return _selectedTask ?? (_selectedTask = Tasks.FirstOrDefault());
            }
            set
            {
                _selectedTask = value;
                OnPropertyChanged("SelectedTask");
                
            }
        }


        #endregion

        
    }
}
