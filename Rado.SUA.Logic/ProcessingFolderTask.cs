using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rado.SUA.Logic
{
    public class ProcessingFolderTask : UpgradeOperationTask
    {
        
        #region Constructor       
        public ProcessingFolderTask()
        {
            
        }
        #endregion

        #region Property
        public string Folder { get; set; }
        public string Name { get; set; }

        #endregion
    }
}
