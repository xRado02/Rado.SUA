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
    public class DeleteFileTask : WorkingOnFilesTask
    {
        #region Contructor

        public DeleteFileTask()
        {
            Label = "DeleteFileTask";
            Files = new List<string>();
        }
        public DeleteFileTask(List<string> files, string description)
        {
            Label = "DeleteFileTask";
            Files = files;
            Description = description;
            
        }
        #endregion

        #region Propierties         

        #endregion

        #region Method

        public override void Execute(List<PlaceholderData> placeholders, int index)
        {
            foreach (var path in Files)
            {
                var placeholderService = new PlaceholderService();
                var changedPath = placeholderService.Replace(path, placeholders);
                if (File.Exists(changedPath))
                {
                    File.Delete(changedPath);
                }
            }
        }

        #endregion



    }
}
