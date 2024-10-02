using Rado.SUA.Windows.TasksWindow;

namespace Rado.SUA.ViewModel.Definition
{
    public class UnpackFolderTaskDefinitionViewModel : OperationTaskDefinitionViewModel
    {
        #region Constructors
        public UnpackFolderTaskDefinitionViewModel()
        {
            Type = TaskType.UnpackFolder;
            Label = "Unpack Folder";            
        }
        #endregion
        #region Method
        public override TaskWindow CreateWindow()
        {
            return new UnpackFolderTaskWindow(this);
        }
        #endregion
    }
}
