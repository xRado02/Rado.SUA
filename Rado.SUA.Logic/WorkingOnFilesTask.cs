using System.Collections.Generic;

namespace Rado.SUA.Logic
{
    public class WorkingOnFilesTask : UpgradeOperationTask
    {
        #region Constructor       
        public WorkingOnFilesTask()
        {
            Files = new List<string>();
        }
        #endregion

        #region Properties
        public List<string> Files { get; set; }
        #endregion
    }
}
