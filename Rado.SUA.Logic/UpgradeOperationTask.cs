using Rado.SUA.Logic.DomainMyBase;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Rado.SUA.Logic
{
    [Serializable]
    [XmlInclude(typeof(CopyFileTask))]
    [XmlInclude(typeof(CopyFolderTask))]
    [XmlInclude(typeof(DeleteFileTask))]
    [XmlInclude(typeof(StartServiceTask))]
    [XmlInclude(typeof(StopServiceTask))]
    [XmlInclude(typeof(PackFolderTask))]
    [XmlInclude(typeof(UnpackFolderTask))]
    [XmlInclude(typeof(DeleteFolderTask))]
    [XmlInclude(typeof(StartAppTask))]
    [XmlInclude(typeof(FindAndZipFileTask))]
    public class UpgradeOperationTask : Mybase
    {
        #region Method
        public virtual void Execute(List<PlaceholderData> placeholders, int index)
        {

        }
        #endregion

        #region Properties
        public string Label { get; set; }
        public string Description { get; set; }
        public string FullInformation { get; set; }
        #endregion
    }
}
