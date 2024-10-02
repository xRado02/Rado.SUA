using Rado.SUA.Logic;
using System.IO;
using System.Xml.Serialization;

namespace Rado.SUA.Service
{
    public class UpgradeOperationRepositoryService
    {
        public UpgradeOperationRepositoryService(string repositoryFilePath)
        {
            RepositoryFilePath = repositoryFilePath;
        }
        public string RepositoryFilePath { get; set; }

        public void SaveDataRepository(UpgradeOperationRepository repository)
        {
            var serializer = new XmlSerializer(typeof(UpgradeOperationRepository));
            using (FileStream fs = new FileStream(RepositoryFilePath, FileMode.Create))
            {
                serializer.Serialize(fs, repository); 
            }
          
        }
       
        public UpgradeOperationRepository LoadDataRepository()
        {
            if (!File.Exists(RepositoryFilePath)) return null;

            var serializer = new XmlSerializer(typeof(UpgradeOperationRepository));
            using (var reader = new StreamReader(RepositoryFilePath))
            {
                return  (UpgradeOperationRepository)serializer.Deserialize(reader);    
            }
           
        }

    }
}
