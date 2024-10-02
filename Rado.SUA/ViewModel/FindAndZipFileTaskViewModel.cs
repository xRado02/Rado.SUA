using Rado.SUA.Logic;
using System.ComponentModel;

namespace Rado.SUA.ViewModel
{
    public class FindAndZipFileTaskVIewModel : UpgradeOperationTaskViewModel, INotifyPropertyChanged
    {
        #region Constructor

        private string _folder;
        public FindAndZipFileTaskVIewModel()        {
            
        }
        public FindAndZipFileTaskVIewModel(FindAndZipFileTask findAndZipFileTask)
        {
            Folder = findAndZipFileTask.Folder;
            Name = findAndZipFileTask.Name;
            StartNumber = findAndZipFileTask.StartNumber;
            Label = findAndZipFileTask.Label;
            Description = findAndZipFileTask.Description;            
        }

        public FindAndZipFileTaskVIewModel(FindAndZipFileTaskVIewModel src)
        {
            this.Label = src.Label;
            this.Folder = src.Folder;
            this.Name = src.Name;
            this.StartNumber = src.StartNumber;
            this.Description = src.Description;
        }

        #endregion
        #region Properties
                
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
        public string Name { get; set; }
        public string StartNumber { get; set; }

        #endregion

        public override UpgradeOperationTask Create()
        {
            return new FindAndZipFileTask(Folder, Name, StartNumber, Description);
        }
        public override UpgradeOperationTaskViewModel Clone()
        {
            return new FindAndZipFileTaskVIewModel(this);
        }
        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            var task = src as FindAndZipFileTaskVIewModel;
            this.Folder = task.Folder;
            this.Name = task.Name;
            this.StartNumber = task.StartNumber;
            this.Description = task.Description;
        }
    }
}
