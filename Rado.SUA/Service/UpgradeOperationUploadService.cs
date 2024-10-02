using Rado.SUA.ViewModel;

namespace Rado.SUA.Service
{
    class UpgradeOperationUploadService
    {
        public UpgradeOperationRepositoryViewModel UploadFiles(string pathRepository)
        {
            var repositoryService = new UpgradeOperationRepositoryService(pathRepository);

            var repository = repositoryService.LoadDataRepository();
            if (repository == null) return null;

            var repositoryConverter = new UpgradeOperationRepositoryConverter();
            var repositoryViewModel = repositoryConverter.ConvertToViewModel(repository);

            return repositoryViewModel;
        }
        
    }
}
