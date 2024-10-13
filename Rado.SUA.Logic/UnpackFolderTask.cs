using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Rado.SUA.Logic.Service;


namespace Rado.SUA.Logic
{
    [Serializable]
    public class UnpackFolderTask : ProcessingFolderTask
    {
        #region Constructor
        public UnpackFolderTask()
        {
            Label = "UnpackFolderTask";
        }
        public UnpackFolderTask(string name, string folder, string description)
        {
            Label = "UnpackFolderTask";
            Name = name;
            Folder = folder;
            Description = description;
        }

        #endregion

        #region Methods

        public override void Execute(List<PlaceholderData> placeholders, int index)
        {
            var placeholderService = new PlaceholderService();
            var changedZipFolder = placeholderService.Replace(Folder, placeholders);
            var changedFolderName = placeholderService.Replace(Name, placeholders);    
            if(File.Exists(changedZipFolder))
            {
                ZipFile.ExtractToDirectory(changedZipFolder, changedFolderName);
            }

          
            
                      
        }

        #endregion 
    }
}
