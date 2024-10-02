using Rado.SUA.Windows.TasksWindow;

namespace Rado.SUA.ViewModel.Definition
{
    public class FindAndZipFileTaskDefinitionViewModel : OperationTaskDefinitionViewModel
    {
        #region Constructors
        public FindAndZipFileTaskDefinitionViewModel()
        {
            Type = TaskType.FindFileAndZip;
            Label = "Find and Zip File";            
        }
        #endregion
        #region Method
        public override TaskWindow CreateWindow()
        {
            return new FileFinderAndZipTaskWindow(this);
        }

        #endregion 
    }
}
