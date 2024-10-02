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
            var changedFolder = placeholderService.Replace(Folder, placeholders);
            var changedName = placeholderService.Replace(Name, placeholders);
            if (Directory.Exists(changedFolder)) 
            {
                ZipFile.ExtractToDirectory(changedFolder, changedName);
            }
            
        }

        #endregion 
    }
}
