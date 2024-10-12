using ASPLec10Sem3GraphQL.Abstraction;
using ASPLec10Sem3GraphQL.Dto;
using ASPLec10Sem3GraphQL.Models;
using ASPLec10Sem3GraphQL.Repository;
using static ASPLec10Sem3GraphQL.Repository.StorageRepository;

namespace ASPLec10Sem3GraphQL.Graph.Query
{
    public class Query(IProductRepository productRepository, IStorageRepository storageRepository)
    {
        //public Query(IProductRepository productRepository) { }

     
        public IEnumerable<ProductDto> GetProducts() =>
            productRepository.GetAllProducts();
        public IEnumerable<ProductGroupDto> GetProductGroups([Service] IProductGroupRepository groupRepository) => //было ProductGroupRepository вместо IProductGroupRepository
            groupRepository.GetAllProductGroups();
        public IEnumerable<StorageDto> GetStorage() =>  //добавил для дз
            storageRepository.GetAllStorages();
       

    }

}
