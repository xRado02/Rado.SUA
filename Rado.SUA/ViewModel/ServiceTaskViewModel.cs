using Rado.SUA.Logic;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Rado.SUA.ViewModel
{
    public abstract class ServiceTaskViewModel : UpgradeOperationTaskViewModel
    {
        #region Constructor
        public ServiceTaskViewModel()
        {
            Services = new ObservableCollection<string>();
        }
        public ServiceTaskViewModel(ServiceTask serviceTask)
        {
            Services = new ObservableCollection<string>();
            Description = serviceTask.Description;
            foreach (var service in serviceTask.Services)
            {
                Services.Add(service);
            } //???? Ta pętla nie jest tu potrzebna
        }
        #endregion

        #region Properties
        public ObservableCollection<string> Services { get; set; }
        #endregion

        public override UpgradeOperationTask Create()
        {
            throw new NotImplementedException("Did not declare implementation.");
        }
        public override UpgradeOperationTaskViewModel Clone()
        {
            throw new NotImplementedException("Did not declare implementation.");
        }
        public override void Cancel(UpgradeOperationTaskViewModel src)
        {
            throw new NotImplementedException("Did not declare implementation.");
        }       
    }
}
