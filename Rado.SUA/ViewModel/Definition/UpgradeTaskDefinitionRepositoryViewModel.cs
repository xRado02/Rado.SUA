using System.Linq;
using System.Collections.ObjectModel;

namespace Rado.SUA.ViewModel.Definition
{
    public class UpgradeTaskDefinitionRepositoryViewModel
    {
        private static UpgradeTaskDefinitionRepositoryViewModel _singleton;

        private OperationTaskDefinitionViewModel _selectedType;
        
        #region Constructor
        public UpgradeTaskDefinitionRepositoryViewModel()
        {
            Definitions = new ObservableCollection<OperationTaskDefinitionViewModel>();
        }

        #endregion

        #region Properties

        public static UpgradeTaskDefinitionRepositoryViewModel Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new UpgradeTaskDefinitionRepositoryViewModel();
                    _singleton.Init();
                }

                return _singleton;
            }
        }

        public ObservableCollection<OperationTaskDefinitionViewModel> Definitions { get; set; }
        public OperationTaskDefinitionViewModel SelectedType 
        {
            get
            {
                return _selectedType;
            }
            set 
            {
                _selectedType = value;      
            } 
        }

        #endregion

        #region Methods
        private void Init()
        {
            Definitions.Add(new CopyFileTaskDefinitionViewModel());
            Definitions.Add(new CopyFolderTaskDefinitionViewModel());
            Definitions.Add(new DeleteFileTaskDefinitionViewModel());
            Definitions.Add(new DeleteFolderTaskDefinitionViewModel());
            Definitions.Add(new FindAndZipFileTaskDefinitionViewModel());
            Definitions.Add(new PackFolderTaskDefinitionViewModel());
            Definitions.Add(new StartAppTaskDefinitionViewModel());
            Definitions.Add(new StartServiceTaskDefinitionViewModel());
            Definitions.Add(new StopServiceTaskDefinitionViewModel());
            Definitions.Add(new UnpackFolderTaskDefinitionViewModel());
            
            _selectedType = Definitions.First();
        }

        #endregion
    }
}