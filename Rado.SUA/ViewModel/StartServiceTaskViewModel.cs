using System.Collections.ObjectModel;
using System.ComponentModel;
using Rado.SUA.Logic;
using System.Linq;


namespace Rado.SUA.ViewModel
{
    public class StartServiceTaskViewModel : ServiceTaskViewModel
    {
        #region Constructor       
        public StartServiceTaskViewModel()
        {
            
        }

        public StartServiceTaskViewModel(StartServiceTask startServiceTask) : base(startServiceTask)
        {
            
        }
        public StartServiceTaskViewModel(StartServiceTaskViewModel src)
        {
            this.Services = src.Services;
            this.Description = src.Description;
            this.Label = src.Label;
        }
        #endregion
        #region Properties

        #endregion

        #region Method
        public override UpgradeOperationTask Create()
        {
            return new StartServiceTask(Services.ToList(), Description);
        }
        public override UpgradeOperationTaskViewModel Clone()
        {
            return new StartServiceTaskViewModel(this);
        }
        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            var task = src as StartServiceTaskViewModel;
            this.Services = task.Services;
            this.Description = task.Description;
        }
        #endregion
    }
}
