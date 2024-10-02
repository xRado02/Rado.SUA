using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rado.SUA.Logic;

namespace Rado.SUA.ViewModel
{
    public class StartAppTaskViewModel : UpgradeOperationTaskViewModel
    {
        #region Fields
        private string _name;        
        #endregion

        #region Constructor
        public StartAppTaskViewModel()
        {

        }
        public StartAppTaskViewModel(StartAppTask startAppTask)
        {
            Name = startAppTask.Name;
            Description = startAppTask.Description;
        }
        public StartAppTaskViewModel(StartAppTaskViewModel src)
        {
            this.Label = src.Label;
            this.Name = src.Name;
            this.Description = src.Description;
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
        #endregion
        #region Method
        public override UpgradeOperationTask Create()
        {
            return new StartAppTask(Name, Description);
        }
        public override UpgradeOperationTaskViewModel Clone()
        {
            return new StartAppTaskViewModel(this);
        }
        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            var task = src as StartAppTaskViewModel;            
            this.Name = task.Name;
            this.Description = task.Description;
        }
        #endregion
    }
}
