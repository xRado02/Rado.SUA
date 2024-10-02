using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rado.SUA.Logic
{
    public class PlaceholderData
    {
        
        #region Constructor
        public PlaceholderData()
        {
            
        }
        public PlaceholderData(PlaceholderCode code, string value)
        {
            Value = value;
            Code = code;
        }       

        #endregion

        #region Properties

        public PlaceholderCode Code { get; }       
        public string Value { get; }

        #endregion
       

    }
}
