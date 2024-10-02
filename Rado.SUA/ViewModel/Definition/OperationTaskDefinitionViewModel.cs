using Rado.SUA.Windows.TasksWindow;

namespace Rado.SUA.ViewModel.Definition
{
    public abstract class OperationTaskDefinitionViewModel 
    {   
        #region Properties

        public TaskType Type { get; set; }
        public string Label { get; set; }        
       

        #endregion

        public abstract TaskWindow CreateWindow();
    }
}