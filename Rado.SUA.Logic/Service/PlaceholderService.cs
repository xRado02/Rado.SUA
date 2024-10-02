using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rado.SUA.Logic.Service
{
    public class PlaceholderService
    {
        #region Methods

        // <summary>
        // inPutText is the parametr, which contain text where is a change (for example path: D:\Test\<version>)
        // placeholders.Value is the parametr, which contain text which will change (for example <version> 1.1.1 to 1_1_1)
        
        public string Replace(string inPutText, List<PlaceholderData> placeholers)
        {
            string replacedText = inPutText;
            foreach(var placeholder in placeholers)
            {
                replacedText = replacedText.Replace($"<{placeholder.Code.ToString().ToLower()}>", placeholder.Value.Replace(".", "_"));                 
            }
            return replacedText;
        }      
        #endregion
    }
}
