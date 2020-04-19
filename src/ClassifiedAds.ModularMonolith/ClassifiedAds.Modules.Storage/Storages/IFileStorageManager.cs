using ClassifiedAds.Modules.Storage.Entities;
using System.IO;

namespace ClassifiedAds.Modules.Storage.Storages
{
    public interface IFileStorageManager
    {
        void Create(FileEntry fileEntry, MemoryStream stream);
        byte[] Read(FileEntry fileEntry);
        void Delete(FileEntry fileEntry);
    }
}
