using System.Collections.ObjectModel;
using System.Linq;
using Rado.SUA.ViewModel.MyBase;
using System;

namespace Rado.SUA.ViewModel
{
    public class UpgradeOperationViewModel : MyBaseViewModel
    {
        #region Fields

        private UpgradeOperationPhaseViewModel _selectedPhase;
        
        #endregion

        public UpgradeOperationViewModel()
        {
            Phases = new ObservableCollection<UpgradeOperationPhaseViewModel>();           
        }

        #region Properties
        public string Name { get; set; }        
        public ObservableCollection<UpgradeOperationPhaseViewModel> Phases { get; }

        public UpgradeOperationPhaseViewModel SelectedPhase
        {
            get
            {
                return _selectedPhase ?? (_selectedPhase = Phases.FirstOrDefault());
            }
            set
            {
                _selectedPhase = value;
                OnPropertyChanged("SelectedPhase");
            }

        }
        public bool IsAnyPhase
        {
            get
            {
                return Phases.Count > 0;
            }
        }

        #endregion

        public void AddPhase(UpgradeOperationPhaseViewModel upgradeOperationPhase)
        {            
            Phases.Add(upgradeOperationPhase);
            upgradeOperationPhase.Id = Guid.NewGuid();
            OnPropertyChanged("IsAnyPhase");
        }
    } 

        
}
