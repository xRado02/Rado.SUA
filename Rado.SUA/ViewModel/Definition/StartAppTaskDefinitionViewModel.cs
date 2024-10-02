using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rado.SUA.Windows.TasksWindow;

namespace Rado.SUA.ViewModel.Definition
{
    public class StartAppTaskDefinitionViewModel : OperationTaskDefinitionViewModel
    {
        public StartAppTaskDefinitionViewModel()
        {
            Type = TaskType.StartApp;
            Label = "Start App";            
        }
        #region Method
        public override TaskWindow CreateWindow()
        {
            return new StartAppTaskWindow(this);
        }
        #endregion
    }
}
