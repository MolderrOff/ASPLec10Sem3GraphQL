using ASPLec10Sem3GraphQL.Dto;

namespace ASPLec10Sem3GraphQL.Abstraction
{
    public interface IStorageRepository //добавил для дз
    {
        IEnumerable<StorageDto> GetAllStorages();
        int AddStorage(StorageDto storageDto);
        void DeleteStorage(int id);
    }
}
