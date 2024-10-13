using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Rado.SUA.Logic.Service;

namespace Rado.SUA.Logic
{
    [Serializable]
    public class CopyFolderTask : UpgradeOperationTask
    {
        public CopyFolderTask()
        {
            Label = "CopyFolderTask";
            Folders = new List<string>();
        }
        public CopyFolderTask(List<string> folders,string copyTo, string description)
        {
            Label = "CopyFolderTask";
            CopyTo = copyTo;
            Folders = folders;
            Description = description;

        }

        #region Properties
        public List<string> Folders { get; set; }
        public string CopyTo { get; set; }

        #endregion

        #region Methods
        public override void Execute(List<PlaceholderData> placeholders, int index)
        {
            foreach (var path in Folders)
            {
                var placeholderService = new PlaceholderService();
                var changedPath = placeholderService.Replace(path, placeholders);
                string sourcePath = changedPath;
                string destinationPath = Path.Combine(CopyTo, Path.GetFileName(sourcePath));
                CopyDirectory(sourcePath, destinationPath, placeholders);
            }
        }

        private void CopyDirectory(string sourcePath, string targetPath, List<PlaceholderData> placeholders)
        {       
            if(Directory.Exists(sourcePath)) 
            {
                foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                {                    
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                }
            }
            
            if(Directory.Exists(sourcePath))
            {
                foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                {
                    if (File.Exists(newPath))
                    {
                        File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                    }
                    else { }
                }
            }
           
        }
        #endregion
    }
}
