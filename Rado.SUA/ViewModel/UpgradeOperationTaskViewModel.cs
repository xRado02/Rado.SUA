using Rado.SUA.ViewModel.Definition;
using Rado.SUA.ViewModel.MyBase;
using System.Collections.ObjectModel;
using Rado.SUA.Logic;
using System;

namespace Rado.SUA.ViewModel
{
    public abstract class UpgradeOperationTaskViewModel : MyBaseViewModel
    {        
        public UpgradeOperationTaskViewModel()
        {
            
        }

        #region Properties
        public string Label { get; set; }                
        public OperationTaskDefinitionViewModel Definition { get; set; }
        public string Description { get; set; } 
        public string FullInformation
        {
            get 
            {   
                return string.Format("{0} - {1}", Definition.Label, Description);                
            }
            set
            {
               
            }
        } 

        #endregion

        public abstract UpgradeOperationTask Create();

        public abstract UpgradeOperationTaskViewModel Clone();

        public abstract void Cancel(UpgradeOperationTaskViewModel src);
        
       

    }
}
