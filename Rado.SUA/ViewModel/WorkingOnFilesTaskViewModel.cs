using Rado.SUA.Logic;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Rado.SUA.ViewModel
{
    public class WorkingOnFilesTaskViewModel : UpgradeOperationTaskViewModel
    {
        #region Fields
        public string _pathToEdit;
        #endregion

        #region Constructor

        public WorkingOnFilesTaskViewModel()
        {
            Files = new ObservableCollection<string>();
        }
        public WorkingOnFilesTaskViewModel(WorkingOnFilesTask workingOnFilesTask)
        {
            Files = new ObservableCollection<string>();
        }

        #endregion

        #region Properties

        public string PathToEdit
        {
            get
            {
                return _pathToEdit;
            }
            set
            {
                _pathToEdit = value;
                OnPropertyChanged("PathToEdit");
            }
        }

        public ObservableCollection<string> Files { get; set; }
        #endregion


        #region Methods

        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            throw new NotImplementedException();
        }
        public override UpgradeOperationTaskViewModel Clone()
        {
            throw new NotImplementedException();
        }
        public override UpgradeOperationTask Create()
        {
            throw new NotImplementedException();
        }

        #endregion
    }


}
