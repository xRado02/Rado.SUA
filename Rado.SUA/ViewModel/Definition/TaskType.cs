using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rado.SUA.ViewModel.Definition
{
    public enum TaskType
    {
        CopyFile,
        CopyFolder,
        DeleteFile,
        DeleteFolder,
        FindFileAndZip,
        PackFolder,
        StartApp,
        StartService,
        StopService,
        UnpackFolder        
    }
}
