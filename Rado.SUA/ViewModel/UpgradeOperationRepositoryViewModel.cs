using Rado.SUA.ViewModel.MyBase;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Rado.SUA.Logic;
using System.Xml.Serialization;

namespace Rado.SUA.ViewModel
{
    [Serializable]    
    public class UpgradeOperationRepositoryViewModel : MyBaseViewModel
    {
        #region Fields
        private UpgradeOperationViewModel _selectedOperation;
        private string _selectedEnvironment;
        private string _selectedExEnvironment;
        #endregion

        #region Constructors
        public UpgradeOperationRepositoryViewModel()
        {
            Operations = new ObservableCollection<UpgradeOperationViewModel>();
            Environment = new ObservableCollection<string> { "QA", "PRODUCTION", "TEST", "BUSINESS", "DEMO" };
            ExtendedEnvironment = new ObservableCollection<string> { "QA", "PRODUCTION", "TEST", "BUSINESS", "DEMO" };

        }

        #endregion

        #region Properties       
       
        public ObservableCollection<UpgradeOperationViewModel> Operations { get; set; }
        public ObservableCollection<string> Environment { get; set; }
        public ObservableCollection<string> ExtendedEnvironment { get; set; }

        public UpgradeOperationViewModel SelectedOperation
        {
            get
            {
                return _selectedOperation ?? (_selectedOperation = Operations.FirstOrDefault());
            }
            set
            {
                _selectedOperation = value;
                OnPropertyChanged("SelectedOperation");
            }
        }
        public string SelectedEnvironment
        {
            get
            {
                return _selectedEnvironment ?? (_selectedEnvironment = Environment.FirstOrDefault());
            }
            set
            {
                _selectedEnvironment = value;
                OnPropertyChanged("SelectedEnvironment");
            }
        }
        public string SelectedExEnvironment
        {
            get
            {
                return _selectedExEnvironment ?? (_selectedExEnvironment = ExtendedEnvironment.FirstOrDefault());
            }
            set
            {
                _selectedExEnvironment = value;
                OnPropertyChanged("SelectedExEnvironment");
            }
        }


        public bool IsAnyOperation
        {
            get
            {
                return Operations.Count > 0;
            }
        }
        public bool IsAnyPhase
        {
            get
            {
                if (_selectedOperation != null)
                {
                    return _selectedOperation.IsAnyPhase;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion
        public void AddOperation(UpgradeOperationViewModel upgradeOperation)
        {
            Operations.Insert(0,upgradeOperation);
            OnPropertyChanged("IsAnyOperation");           
        }
    }
}
