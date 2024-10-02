using Rado.SUA.Logic.Service;
using System;
using System.Collections.Generic;
using System.ServiceProcess;

namespace Rado.SUA.Logic
{
    public class StopServiceTask : ServiceTask
    {
        #region Constructor
        public StopServiceTask()
        {
            Label = "StopServiceTask";
        }
        public StopServiceTask(List<string> services, string description)
        {
            Label = "StopServiceTask";
            Services = services;
            Description = description;
        }
        #endregion

        #region Properties        

        #endregion

        #region Methods
        public override void Execute(List<PlaceholderData> placeholders, int index)
        {
            foreach (var service in Services)
            {
                var placeholderService = new PlaceholderService();                
                var changedServicePath = placeholderService.Replace(service, placeholders);
                ServiceController startService = new ServiceController(changedServicePath);
                startService.Stop();
            }
        }
        #endregion


    }
}
