using System.Collections.ObjectModel;
using System.ComponentModel;
using Rado.SUA.Logic;
using System.Linq;

namespace Rado.SUA.ViewModel
{
    public class CopyFileTaskViewModel : WorkingOnFilesTaskViewModel, INotifyPropertyChanged
    {
        private string _copyTo;
        

        #region Constructor       
        public CopyFileTaskViewModel()
        {
            
        }
        public CopyFileTaskViewModel(CopyFileTask copyTask): base(copyTask)
        {
            Label = copyTask.Label;
            Description = copyTask.Description;           
            foreach (var path in copyTask.Files)
            {
                Files.Add(path);
            }
            CopyTo = copyTask.CopyTo;
        }

        public CopyFileTaskViewModel(CopyFileTaskViewModel src)
        {
            this.Files = src.Files;
            this.CopyTo = src.CopyTo;
            this.Description = src.Description;
            this.Label = src.Label;
        }
        #endregion

        #region Properties         
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

        #endregion

        #region method
        public override UpgradeOperationTask Create()
        {
            return new CopyFileTask(Files.ToList(), CopyTo, Description);            
        }

        public override UpgradeOperationTaskViewModel Clone()
        {           
            return new CopyFileTaskViewModel(this);
        }

        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            var task = src as CopyFileTaskViewModel;
            this.Files = task.Files;
            this.CopyTo = task.CopyTo;
            this.Description = task.Description;
            this.Label = task.Label;
        }
        #endregion
        
    }
}
