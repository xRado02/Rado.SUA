using System;
using Rado.SUA.Logic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Rado.SUA.ViewModel
{
    public class DeleteFolderTaskViewModel : UpgradeOperationTaskViewModel
    {
        #region Constuctor
        public DeleteFolderTaskViewModel()
        {
            FoldersToDelete = new ObservableCollection<string>();
        }
        public DeleteFolderTaskViewModel(DeleteFolderTask deleteFolderTask)
        {
            FoldersToDelete = new ObservableCollection<string>();
            Description = deleteFolderTask.Description;
            foreach (var path in deleteFolderTask.FoldersToDelete)
            {
                FoldersToDelete.Add(path);
            }
        }

        public DeleteFolderTaskViewModel(DeleteFolderTaskViewModel src)
        {
            this.Description = src.Description;            
            this.FoldersToDelete = src.FoldersToDelete;           
        }
        #endregion

        #region Propierties 
        public ObservableCollection<string> FoldersToDelete { get; set; }

        #endregion

        #region method
        public override UpgradeOperationTask Create()
        {
            return new DeleteFolderTask(FoldersToDelete.ToList(), Description);
        }
        public override UpgradeOperationTaskViewModel Clone()
        {
            return new DeleteFolderTaskViewModel(this);
        }
        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            var task = src as DeleteFolderTaskViewModel;
            this.Description = task.Description;
            this.FoldersToDelete = task.FoldersToDelete;
        }

        #endregion
    }
}
