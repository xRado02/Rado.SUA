using System.Collections.Generic;


namespace Rado.SUA.Logic
{
    public abstract class ServiceTask : UpgradeOperationTask
    {
        #region Constructor
        public ServiceTask()
        {
            Services = new List<string>();
        }       
        #endregion

        #region Properties
        public List<string> Services { get; set; }
        #endregion
    }
}
