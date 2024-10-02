using Rado.SUA.Windows.TasksWindow;

namespace Rado.SUA.ViewModel.Definition
{
    public class DeleteFileTaskDefinitionViewModel : OperationTaskDefinitionViewModel
    {
        #region Contructor
        public DeleteFileTaskDefinitionViewModel()
        {
            Type = TaskType.DeleteFile;
            Label = "Delete File";            
        }
        #endregion
        #region Method
        public override TaskWindow CreateWindow()
        {
            return new DeleteTaskWindow(this);
        }

        #endregion 
    }
}