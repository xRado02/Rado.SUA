using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

namespace Rado.SUA.WinService
{
    public partial class MainService : ServiceBase
    {
        Timer timer = new Timer();
        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WritetToFile($"Service is started at: {0}" + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 60000; //number in miliseconds
            timer.Enabled = true;
        }
        protected override void OnStop()
        {
            WritetToFile($"Service is stoped at: {0}" + DateTime.Now);
        }

        private void OnElapsedTime(object sender, EventArgs e)
        {
            WritetToFile($"Service was ran at: {0}" + DateTime.Now);
        }

        private void WritetToFile(string message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog";
            if (!File.Exists(pathFile))
            {
                using (StreamWriter sw = File.CreateText(pathFile))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(pathFile))
                {
                    sw.WriteLine(message);
                }
            }    


        }
    }
}
