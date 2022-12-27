using DataEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer.Interfaces
{
    public interface IFileBO
    {
        List<FileData> GetAllFiles();
        bool SaveFile(FileData file);
    }
}
