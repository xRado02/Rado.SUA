using Rado.SUA.Logic;
using Rado.SUA.ViewModel;
using Rado.SUA.ViewModel.Definition;
using System.Collections.ObjectModel;
using System.Linq;

namespace Rado.SUA.Service
{
    public class UpgradeOperationRepositoryConverter
    {
        public UpgradeOperationRepository ConvertToModel(UpgradeOperationRepositoryViewModel upgradeOperationRepositoryViewModel)
        {            
            var repository = new UpgradeOperationRepository();  
            foreach(var operationVM in upgradeOperationRepositoryViewModel.Operations)
            {
               var operation = new UpgradeOperation();
               operation.Name = operationVM.Name;   
               foreach(var phaseVM in operationVM.Phases)
               {
                    var phase = new UpgradeOperationPhase();
                    phase.Name = phaseVM.Name;
                    phase.Id = phaseVM.Id;
                    foreach(var taskVM in phaseVM.Tasks)
                    {
                        phase.Tasks.Add(taskVM.Create());
                    }
                    operation.Phases.Add(phase);
               }
               repository.Operations.Add(operation);
            }
            return repository;
        }   
        
        public UpgradeOperationRepositoryViewModel ConvertToViewModel(UpgradeOperationRepository upgradeOperationRepository)
        {
            var repositoryViewModel = new UpgradeOperationRepositoryViewModel();
            foreach(var operation in upgradeOperationRepository.Operations)
            {
                var operationVM = new UpgradeOperationViewModel();
                operationVM.Name = operation.Name;
                foreach (var phase in operation.Phases)
                {
                    var phaseVM = new UpgradeOperationPhaseViewModel();
                    phaseVM.Name = phase.Name;
                    phaseVM.Id = phase.Id;
                    foreach (var task in phase.Tasks)
                    {   
                        if(task is CopyFileTask)
                        {    
                            var taskVM = new CopyFileTaskViewModel((CopyFileTask)task);                           
                           
                            taskVM.Description = task.Description;
                            taskVM.Definition = UpgradeTaskDefinitionRepositoryViewModel.Singleton.Definitions.FirstOrDefault(d => d.Type == TaskType.CopyFile);
                            phaseVM.Tasks.Add(taskVM);
                        }                        
                        else if(task is DeleteFileTask)
                        {
                            var taskVM = new DeleteFileTaskViewModel((DeleteFileTask)task);
                            taskVM.Description = task.Description;
                            taskVM.Definition = UpgradeTaskDefinitionRepositoryViewModel.Singleton.Definitions.FirstOrDefault(d => d.Type == TaskType.DeleteFile);
                            phaseVM.Tasks.Add(taskVM);
                        }   
                        else if(task is StartServiceTask)
                        {      
                            var taskVM = new StartServiceTaskViewModel((StartServiceTask)task);
                            taskVM.Description = task.Description;
                            taskVM.Definition = UpgradeTaskDefinitionRepositoryViewModel.Singleton.Definitions.FirstOrDefault(d => d.Type == TaskType.StartService);
                            phaseVM.Tasks.Add(taskVM);
                        }
                        else if(task is StopServiceTask)
                        {
                            var taskVM = new StopServiceTaskViewModel((StopServiceTask)task);
                            taskVM.Description = task.Description;
                            taskVM.Definition = UpgradeTaskDefinitionRepositoryViewModel.Singleton.Definitions.FirstOrDefault(d => d.Type == TaskType.StopService);
                            phaseVM.Tasks.Add(taskVM);
                        }
                        else if (task is PackFolderTask)
                        {
                            var taskVM = new PackFolderTaskViewModel((PackFolderTask)task);
                            taskVM.Description = task.Description;
                            taskVM.Definition = UpgradeTaskDefinitionRepositoryViewModel.Singleton.Definitions.FirstOrDefault(d => d.Type == TaskType.PackFolder);
                            phaseVM.Tasks.Add(taskVM);
                        }
                        else if (task is UnpackFolderTask)
                        {
                            var taskVM = new UnpackFolderTaskViewModel((UnpackFolderTask)task);
                            taskVM.Description = task.Description;
                            taskVM.Definition = UpgradeTaskDefinitionRepositoryViewModel.Singleton.Definitions.FirstOrDefault(d => d.Type == TaskType.UnpackFolder);
                            phaseVM.Tasks.Add(taskVM);
                        }
                        else if (task is DeleteFolderTask)
                        {
                            var taskVM = new DeleteFolderTaskViewModel((DeleteFolderTask)task);
                            taskVM.Description = task.Description;
                            taskVM.Definition = UpgradeTaskDefinitionRepositoryViewModel.Singleton.Definitions.FirstOrDefault(d => d.Type == TaskType.DeleteFolder);
                            phaseVM.Tasks.Add(taskVM);
                        }
                        else if (task is StartAppTask)
                        {
                            var taskVM = new StartAppTaskViewModel((StartAppTask)task);
                            taskVM.Description = task.Description;
                            taskVM.Definition = UpgradeTaskDefinitionRepositoryViewModel.Singleton.Definitions.FirstOrDefault(d => d.Type == TaskType.StartApp);
                            phaseVM.Tasks.Add(taskVM);
                        }
                        else if (task is FindAndZipFileTask)
                        {
                            var taskVM = new FindAndZipFileTaskVIewModel((FindAndZipFileTask)task);
                            taskVM.Description = task.Description;
                            taskVM.Definition = UpgradeTaskDefinitionRepositoryViewModel.Singleton.Definitions.FirstOrDefault(d => d.Type == TaskType.FindFileAndZip);
                            phaseVM.Tasks.Add(taskVM);
                        }
                        else if (task is CopyFolderTask)
                        {
                            var taskVM = new CopyFolderTaskViewModel((CopyFolderTask)task);

                            taskVM.Description = task.Description;
                            taskVM.Definition = UpgradeTaskDefinitionRepositoryViewModel.Singleton.Definitions.FirstOrDefault(d => d.Type == TaskType.CopyFolder);
                            phaseVM.Tasks.Add(taskVM);
                        }
                    }
                    operationVM.Phases.Add(phaseVM);
                    
                }
                repositoryViewModel.Operations.Add(operationVM);
            }
            return repositoryViewModel;
        }
        
    }
}
