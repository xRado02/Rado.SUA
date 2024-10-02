 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rado.SUA.Logic;

namespace Rado.SUA.ViewModel
{
    public class PackFolderTaskViewModel : ProcessingFolderTaskViewModel, INotifyPropertyChanged
    {
        #region Constructor
        public PackFolderTaskViewModel()
        {

        }
        public PackFolderTaskViewModel(PackFolderTask packFolderTask) : base(packFolderTask)
        {

        }

        public PackFolderTaskViewModel(PackFolderTaskViewModel src)
        {
            this.Folder = src.Folder;
            this.Label = src.Label;
            this.Name = src.Name;
            this.Description = src.Description;
        }
        #endregion

        public override UpgradeOperationTask Create()
        {
            return new PackFolderTask(Name, Folder, Description);
        }

        public override UpgradeOperationTaskViewModel Clone()
        {
            return new PackFolderTaskViewModel(this);
        }
        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            var task = src as PackFolderTaskViewModel;
            this.Folder = task.Folder;            
            this.Name = task.Name;
            this.Description = task.Description;
        }
    }
}
