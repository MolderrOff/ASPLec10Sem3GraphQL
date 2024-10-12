using ASPLec10Sem3GraphQL.Abstraction;
using ASPLec10Sem3GraphQL.Dto;
using ASPLec10Sem3GraphQL.Repository;

namespace ASPLec10Sem3GraphQL.Graph.Mutation
{
    public class Mutation(IProductRepository productRepository, IStorageRepository storageRepository) //добавил для дз IStorageRepository storageRepository
    {
        public int  AddProduct(ProductDto productDto) =>  productRepository.AddProduct(productDto) ;
        public int AddProductGroup([Service] IProductGroupRepository productGroupRepository, ProductGroupDto productGroupDto) =>
            productGroupRepository.AddProductGroup(productGroupDto);
        public int AddStorage(StorageDto storageDto) => storageRepository.AddStorage(storageDto);  // Добавил для дз
    }
}
