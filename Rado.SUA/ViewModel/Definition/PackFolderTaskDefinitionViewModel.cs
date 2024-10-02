using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rado.SUA.Windows.TasksWindow;

namespace Rado.SUA.ViewModel.Definition
{
    public class PackFolderTaskDefinitionViewModel : OperationTaskDefinitionViewModel
    {
        #region Constructors
        public PackFolderTaskDefinitionViewModel()
        {
            Type = TaskType.PackFolder;
            Label = "Pack Folder";            
        }
        #endregion
        #region Method
        public override TaskWindow CreateWindow()
        {
            return new PackFolderTaskWindow(this);
        }
        #endregion
    }
}
