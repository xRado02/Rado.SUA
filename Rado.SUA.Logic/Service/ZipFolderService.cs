using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using Rado.SUA.Logic.Service;


namespace Rado.SUA.Logic.Service
{
    public class ZipFolderService
    {
        #region Methods

        public void Zip(string folder, string name, List<PlaceholderData> placeholders)
        {            
            var placeholderService = new PlaceholderService();            
            var changedName = placeholderService.Replace(name, placeholders);
            var changedFolder = placeholderService.Replace(folder, placeholders);
            if (Directory.Exists(changedName)) 
            {
                ZipFile.CreateFromDirectory(changedFolder, changedName);
            }
            
        }

        public void UnZip(string folder, string name, List<PlaceholderData> placeholders)
        {
            var placeholderService = new PlaceholderService();
            var changedName = placeholderService.Replace(name, placeholders);
            var changedFolder = placeholderService.Replace(folder, placeholders);
            if (Directory.Exists(changedFolder)) 
            {
                ZipFile.ExtractToDirectory(changedFolder, changedName); 
            }
                     
        }
        #endregion
    }
}
