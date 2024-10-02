using Rado.SUA.Logic.Service;
using System;
using System.Collections.Generic;
using System.ServiceProcess;


namespace Rado.SUA.Logic
{
    [Serializable]
    public class StartServiceTask : ServiceTask
    {
        #region Constructor
        public StartServiceTask()
        {
            Label = "StartServiceTask";
        }
        public StartServiceTask(List<string> services, string description)
        {
            Label = "StartServiceTask";
            Services = services;
            Description = description;
        }

        #endregion Constructor

        
        #region Method

        public override void Execute(List<PlaceholderData> placeholders, int index)
        {
            foreach (var service in Services)
            {
                var placeholderService = new PlaceholderService();
                var changedServicePath = placeholderService.Replace(service, placeholders);
                ServiceController startService = new ServiceController(changedServicePath);
                startService.Start();                
            }
        }
        

        #endregion

    }
}
