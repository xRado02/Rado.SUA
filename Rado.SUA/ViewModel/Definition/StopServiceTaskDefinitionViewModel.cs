using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rado.SUA.Windows.TasksWindow;

namespace Rado.SUA.ViewModel.Definition
{
    public class StopServiceTaskDefinitionViewModel : OperationTaskDefinitionViewModel
    {
        #region Constructor
        public StopServiceTaskDefinitionViewModel()
        {
            Type = TaskType.StopService;
            Label = "Stop Service";            
        }
        #endregion Constructor
        #region Method
        public override TaskWindow CreateWindow()
        {
            return new StopServiceTaskWindow(this);
        }
        #endregion
    }
}
