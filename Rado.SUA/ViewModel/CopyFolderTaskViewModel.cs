using Rado.SUA.Logic;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel;

namespace Rado.SUA.ViewModel
{
    public class CopyFolderTaskViewModel : UpgradeOperationTaskViewModel, INotifyPropertyChanged
    {

        public string _pathToEdit;
        private string _copyTo;

        #region Constructor

        public CopyFolderTaskViewModel()
        {
            FoldersToCopy = new ObservableCollection<string>();
        }
        public CopyFolderTaskViewModel(CopyFolderTask copyFolder)
        {
            FoldersToCopy = new ObservableCollection<string>();
            Description = copyFolder.Description;
            foreach (var path in copyFolder.Folders)
            {
                FoldersToCopy.Add(path);
            }
            CopyTo = copyFolder.CopyTo;
        }

        public CopyFolderTaskViewModel(CopyFolderTaskViewModel src)
        {
            this.Description = src.Description;
            this.FoldersToCopy = src.FoldersToCopy;
            this.CopyTo = src.CopyTo;
        }

        #endregion

        #region Properties

        public ObservableCollection<string> FoldersToCopy { get; set; }
        public string CopyTo
        {
            get
            {
                return _copyTo;
            }
            set
            {
                _copyTo = value;
                OnPropertyChanged("CopyTo");
            }
        }
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

        #endregion

        #region Methods
        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            var task = src as CopyFolderTaskViewModel;
            this.Description = task.Description;
            this.CopyTo = task.CopyTo;
            this.FoldersToCopy = task.FoldersToCopy;
        }

        public override UpgradeOperationTaskViewModel Clone()
        {
            return new CopyFolderTaskViewModel(this);
        }

        public override UpgradeOperationTask Create()
        {
            return new CopyFolderTask(FoldersToCopy.ToList(),CopyTo, Description);
        }

        #endregion
    }
}
