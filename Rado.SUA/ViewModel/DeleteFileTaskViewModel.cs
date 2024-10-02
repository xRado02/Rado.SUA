using Rado.SUA.Logic;
using System.Collections.ObjectModel;
using System.Linq;


namespace Rado.SUA.ViewModel
{
    public class DeleteFileTaskViewModel : WorkingOnFilesTaskViewModel
    {
        #region Contructor

        public DeleteFileTaskViewModel()
        {
            
        }
        public DeleteFileTaskViewModel(DeleteFileTask deleteFileTask) :base(deleteFileTask)
        {
            foreach(var path in deleteFileTask.Files)
            {
                Files.Add(path);
            }
        }

        public DeleteFileTaskViewModel(DeleteFileTaskViewModel src)
        {            
            this.Files = src.Files;
            this.Description = src.Description;
        }
        #endregion

        #region Propierties 

        #endregion

        #region method
        public override UpgradeOperationTask Create()
        {
            return new DeleteFileTask(Files.ToList(), Description);
        }

        public override UpgradeOperationTaskViewModel Clone()
        {
            return new DeleteFileTaskViewModel(this);
        }
        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            var task = src as DeleteFileTaskViewModel;
            this.Files = task.Files;
            this.Description = task.Description;
        }
        #endregion
    }
}
