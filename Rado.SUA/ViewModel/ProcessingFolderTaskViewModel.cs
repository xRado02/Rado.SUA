using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rado.SUA.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Rado.SUA.Logic;

namespace Rado.SUA
{
    public class ProcessingFolderTaskViewModel : UpgradeOperationTaskViewModel, INotifyPropertyChanged
    {
        #region Fields
        private string _name;
        private string _folder;
        #endregion

        #region Constructors
        public ProcessingFolderTaskViewModel()
        {
            
        }
        public ProcessingFolderTaskViewModel(ProcessingFolderTask processingFileTask)
        {
            Name = processingFileTask.Name;
            Description = processingFileTask.Description;
            Folder = processingFileTask.Folder;
        }
        #endregion
        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Folder 
        {
            get
            {
                return _folder;
            }
            set
            {
                _folder = value;
                OnPropertyChanged("Folder");
            }
        }
        #endregion

        #region Methods

        public override UpgradeOperationTask Create()
        {
            throw new NotImplementedException("Did not declare implementation.");
        }
        public override UpgradeOperationTaskViewModel Clone()
        {
            throw new NotImplementedException("Did not declare implementation.");
        }
        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            throw new NotImplementedException("Did not declare implementation");
        }
        #endregion 



    }
}
