using Rado.SUA.Windows.TasksWindow;

namespace Rado.SUA.ViewModel.Definition
{
    public class DeleteFolderTaskDefinitionViewModel : OperationTaskDefinitionViewModel
    {
        #region Constructor 
            
        public DeleteFolderTaskDefinitionViewModel()
        {
            Type = TaskType.DeleteFolder;
            Label = "Delete Folder";           
        }
        #endregion
        #region Method
        public override TaskWindow CreateWindow()
        {
            return new DeleteFoldertTaskWindow(this);
        }

        #endregion 

    }
}
