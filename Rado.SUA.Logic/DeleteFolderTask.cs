using System;
using System.Collections.Generic;
using System.IO;

namespace Rado.SUA.Logic
{
    [Serializable]
    public class DeleteFolderTask : UpgradeOperationTask
    {
        #region Constructor
        public DeleteFolderTask()
        {
            Label = "DeleteFolderTask";
            FoldersToDelete = new List<string>();
        }
        public DeleteFolderTask(List<string> foldersToDielete, string description)
        {
            Label = "DeleteFolderTask";
            FoldersToDelete = foldersToDielete;
            Description = description;
        }
        #endregion

        #region Propierties 
        public List<string> FoldersToDelete { get; set; }

        #endregion

        #region Method

        public override void Execute(List<PlaceholderData> placeholders, int index)
        {
            foreach (var path in FoldersToDelete)
            {   
                if (Directory.Exists(path))
                {                   
                    Directory.Delete(path, true);
                }
               
            }

        }

        #endregion
    }
}
