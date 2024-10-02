using Rado.SUA.Logic.DomainMyBase;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace Rado.SUA.Logic
{
    [Serializable]
    public class UpgradeOperationRepository : Mybase
    {        

        #region Constructors       
        public UpgradeOperationRepository()
        {
            Operations = new List<UpgradeOperation>();
            Environment = Enum.GetNames(typeof(PlaceholderCode)).ToList();
            ExtendedEnvironment = Enum.GetNames(typeof(PlaceholderCode)).ToList();
        }

        #endregion

        #region Properties

        public List<UpgradeOperation> Operations { get; set; }
        public List<string> Environment { get; set; }
        public List<string> ExtendedEnvironment { get; set; }
        #endregion
    }

}

