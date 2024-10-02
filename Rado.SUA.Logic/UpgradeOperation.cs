using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Rado.SUA.Logic.DomainMyBase;
using Rado.SUA;

namespace Rado.SUA.Logic
{
    public class UpgradeOperation : Mybase
    {        

        public UpgradeOperation()
        {
            Phases = new List<UpgradeOperationPhase>();

        }

        #region Properties
        public string Name { get; set; }      
        public List<UpgradeOperationPhase> Phases { get; }

        #endregion

        #region Methods

        
        #endregion  

    }
}

