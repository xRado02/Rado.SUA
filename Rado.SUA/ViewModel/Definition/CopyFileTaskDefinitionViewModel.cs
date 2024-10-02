using Rado.SUA.Windows.TasksWindow;


namespace Rado.SUA.ViewModel.Definition
{
    public class CopyFileTaskDefinitionViewModel : OperationTaskDefinitionViewModel
    {
        #region Constructor
        public CopyFileTaskDefinitionViewModel()
        {
            Type = TaskType.CopyFile;
            Label = "Copy File";  
        }
        #endregion
        #region Method
        public override TaskWindow CreateWindow()
        {
            return new CopyTaskWindow(this);
        }
        #endregion

    }
}
