using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using Rado.SUA.Logic.Service;

namespace Rado.SUA.Logic
{
    [Serializable]
    public class PackFolderTask : ProcessingFolderTask
    {
        #region Constructor
        public PackFolderTask()
        {
            Label = "PackFolderTask";
        }
        public PackFolderTask(string name, string folder, string description)
        {
            Label = "PackFolderTask";
            Name = name;
            Folder = folder;
            Description = description;
        }

        #endregion

        #region Methods
        public override void Execute(List<PlaceholderData> placeholders, int index)
        {           
            var zipService = new ZipFolderService();
            if (Directory.Exists(Folder))
            {
                zipService.Zip(Folder, Name, placeholders);
            }
                      
        }

        #endregion  
    }
}
