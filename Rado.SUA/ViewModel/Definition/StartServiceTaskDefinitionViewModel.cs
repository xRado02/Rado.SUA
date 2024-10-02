using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rado.SUA.Windows.TasksWindow;

namespace Rado.SUA.ViewModel.Definition
{
    public class StartServiceTaskDefinitionViewModel : OperationTaskDefinitionViewModel
    {
        #region Constructor
        public StartServiceTaskDefinitionViewModel()
        {
            Type = TaskType.StartService;
            Label = "Start Service";            
        }
        #endregion
        #region Method
        public override TaskWindow CreateWindow()
        {
            return new StartServiceWindow(this);
        }
        #endregion
    }
}
