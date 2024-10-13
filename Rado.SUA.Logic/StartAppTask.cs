using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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

            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = Path.GetFileName(Name);
            //startInfo.WorkingDirectory = Path.GetDirectoryName(Name) + @"\";
            //startInfo.WindowStyle = ProcessWindowStyle.Normal; 
            //startInfo.UseShellExecute = false;
            //Process process = Process.Start(startInfo);
            //Process process = new Process();
            //process.StartInfo.FileName = Path.GetFileName(Name);
            //process.StartInfo.WorkingDirectory = Path.GetDirectoryName(Name);
            //process.StartInfo.UseShellExecute = true;
            //process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            //process.Start();
            //process.WaitForExit();

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c \"" + Path.GetFileName(Name) + "\"";
            process.StartInfo.WorkingDirectory = Path.GetDirectoryName(Name);
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();
            process.WaitForExit();
        }
        #endregion

    }
}
