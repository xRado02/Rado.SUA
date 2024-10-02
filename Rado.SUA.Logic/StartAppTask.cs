using System.Collections.Generic;
using System.Diagnostics;

namespace Rado.SUA.Logic
{
    public class StartAppTask : UpgradeOperationTask
    {
        #region Constructor
        public StartAppTask()
        {
            Label = "StartAppTask";
        }
        public StartAppTask(string name, string description)
        {
            Label = "StartAppTask";
            Name = name;
            Description = description;
        }

        #endregion

        #region Properties
        public string Name { get; set; }       
        #endregion

        #region Method

        public override void Execute(List<PlaceholderData> placeholders, int index)
        {
            Process process = new Process();
            process.StartInfo.FileName = Name;            
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;            
            process.Start();
            process.WaitForExit();
        }
        #endregion

    }
}
