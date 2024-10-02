using Rado.SUA.Logic;
using System.ComponentModel;

namespace Rado.SUA.ViewModel
{
    public class UnpackFolderTaskViewModel : ProcessingFolderTaskViewModel, INotifyPropertyChanged
    {
        public UnpackFolderTaskViewModel()
        {

        }
        public UnpackFolderTaskViewModel(UnpackFolderTask unpackFolderTask) : base(unpackFolderTask)
        {

        }

        public UnpackFolderTaskViewModel(UnpackFolderTaskViewModel src)
        {
            this.Folder = src.Folder;
            this.Label = src.Label;
            this.Name = src.Name;
            this.Description = src.Description;
        }

        public override UpgradeOperationTask Create()
        {
            return new UnpackFolderTask(Name, Folder, Description);
        }
        public override UpgradeOperationTaskViewModel Clone()
        {
            return new UnpackFolderTaskViewModel();
        }
        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            var task = src as UnpackFolderTaskViewModel;
            this.Folder = task.Folder;            
            this.Name = task.Name;
            this.Description = task.Description;
        }
    }
}
