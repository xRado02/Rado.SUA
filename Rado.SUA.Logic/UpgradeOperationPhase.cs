using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Rado.SUA.Logic
{
    public class UpgradeOperationPhase
    {
        
        public UpgradeOperationPhase()
        {
            Tasks = new List<UpgradeOperationTask>();            
        }

        #region Properties
        public string Name { get; set; }
        public Guid Id { get; set; }
        public List<UpgradeOperationTask> Tasks { get; set; }      

        #endregion

    }
}
