using Rado.SUA.Logic.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace Rado.SUA.Logic
{
    [Serializable]
    public class FindAndZipFileTask : UpgradeOperationTask
    {
        #region Constructor
        public FindAndZipFileTask()
        {
            Label = "FindAndZipFile";
        }
        public FindAndZipFileTask(string folder, string name, string startNumber, string description)
        {
            Label = "FindAndZipFile";
            Folder = folder;
            Name = name;
            StartNumber = startNumber;
            Description = description;
        }
        #endregion
        #region Properties        
        public string Folder { get; set; }
        public string Name { get; set; }
        public string StartNumber { get; set; }//usunac?
        #endregion

        #region Methods

        public override void Execute(List<PlaceholderData> placeholders, int startIndex)
        {
            var zipService = new ZipFolderService();
            var createdFolderName = "folder";           
            var pathToZipFolder = Path.Combine(Folder, createdFolderName);
            Directory.CreateDirectory(pathToZipFolder);
            FindFilesToCopy(pathToZipFolder, startIndex);
            if (Directory.Exists(pathToZipFolder))
            {
                zipService.Zip(pathToZipFolder, Name, placeholders);
            }            
            var pathToDeleteFolder = Path.Combine(Folder, createdFolderName);
            if (Directory.Exists(pathToDeleteFolder)) 
            {
                Directory.Delete(pathToDeleteFolder, true);
            }
            
        }

        public void FindFilesToCopy(string path, int startNumber)
        {            
            var correctFiles = new List<string>();
            var files = new string[] { };                    
            files = Directory.GetFiles(Folder);           
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var index = fileName.IndexOf("_");
                if (index != -1)
                {
                    var firstNumber = int.Parse(fileName.Substring(0, index));
                    if (startNumber <= firstNumber)
                    {
                        correctFiles.Add(file);
                        firstNumber++;
                    }
                }
                
            }    
            foreach (var correctFile in correctFiles)
            {
                string correcetFileName = Path.GetFileName(correctFile);
                string destinationPath = Path.Combine(path, correcetFileName);
                if (File.Exists(correctFile))
                {
                    File.Copy(correctFile, destinationPath, true);
                }
                else { }
                
            }
        }


        #endregion
    }
}
