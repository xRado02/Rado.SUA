using Rado.SUA.Logic.Service;
using Rado.SUA;
using System;
using System.Collections.Generic;
using System.IO;

namespace Rado.SUA.Logic
{
    [Serializable]
    public class CopyFileTask : WorkingOnFilesTask
    {
        private string _copyTo;
        #region Constructor

        public CopyFileTask()
        {
            Label = "CopyFileTask";            
            Files = new List<string>();
        }
        public CopyFileTask(List<string> files, string copyTo, string descritpion)
        {
            Label = "CopyFileTask";
            Files = files;
            CopyTo = copyTo;
            Description = descritpion;            
        }
        #endregion

        #region Properties        
        public string CopyTo
        {
            get
            {
                return _copyTo;
            }
            set
            {
                _copyTo = value;
                OnPropertyChanged("CopyTo");
            }
        }

        #endregion

        #region Methods

        public override void Execute(List<PlaceholderData> placeholders, int index)
        {
            foreach (var path in Files)
            {
                var placeholderService = new PlaceholderService();
                string fileName = Path.GetFileName(path);
                var changedPath = placeholderService.Replace(path, placeholders);
                string targetFilePath = Path.Combine(CopyTo, fileName);    
                var changedTargetFilePath = placeholderService.Replace(targetFilePath, placeholders);
                if(File.Exists(changedPath)) 
                {
                    File.Copy(changedPath, changedTargetFilePath, true); 
                }
                else{ }
               
            }
        }
        
        #endregion
    }
}

