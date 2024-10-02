using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rado.SUA.Logic;

namespace Rado.SUA.ViewModel
{
    public class StopServiceTaskViewModel : ServiceTaskViewModel
    {
        #region Constructor
        public StopServiceTaskViewModel()
        {

        }

        public StopServiceTaskViewModel(StopServiceTask stopServiceTask) : base(stopServiceTask)
        {

        }
        public StopServiceTaskViewModel(StopServiceTaskViewModel src)
        {
            this.Services = src.Services;
            this.Description = src.Description;
            this.Label = src.Label;
        }

        #endregion       

        #region Method
        public override UpgradeOperationTask Create()
        {
            return new StopServiceTask(Services.ToList(), Description);
        }
        public override UpgradeOperationTaskViewModel Clone()
        {
            return new StopServiceTaskViewModel(this);
        }
        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            var task = src as StopServiceTaskViewModel;
            this.Services = task.Services;
            this.Description = task.Description;
        }
        #endregion
    }
}
