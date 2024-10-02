using Rado.SUA.Windows.TasksWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rado.SUA.ViewModel.Definition
{
    public class CopyFolderTaskDefinitionViewModel : OperationTaskDefinitionViewModel
    {
        #region Constructor
        public CopyFolderTaskDefinitionViewModel()
        {
            Type = TaskType.CopyFolder;
            Label = "Copy Folder";
        }
        #endregion
        #region Method
        public override TaskWindow CreateWindow()
        {
            return new CopyFolderWindow(this);
        }
        #endregion
    }
}
