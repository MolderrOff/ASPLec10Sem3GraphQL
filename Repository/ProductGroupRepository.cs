using AutoMapper;
using ASPLec10Sem3GraphQL.Abstraction;
using ASPLec10Sem3GraphQL.Data;
using ASPLec10Sem3GraphQL.Dto;
using ASPLec10Sem3GraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPLec10Sem3GraphQL.Repository
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        StorageContext storageContext;
        private readonly IMapper _mapper;
        public ProductGroupRepository(StorageContext storageContext, IMapper mapper) //--- удалил StorageContext storageContext, 
        {
            this.storageContext = storageContext;//---
            this._mapper = mapper;
        }
        public int AddProductGroup(ProductGroupDto productGroupDto)
        {
            if (storageContext.ProductGroups.Any(p => p.Name == productGroupDto.Name))
            {
                throw new Exception("Уже существет продуткт с таким именем");
            }

            var entity = _mapper.Map<ProductGroup>(productGroupDto);
            storageContext.ProductGroups.Add(entity);
            storageContext.SaveChanges();
            return entity.Id;
        }

        public void DeleteProductGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductGroupDto> GetAllProductGroups()
        {
            using (storageContext = new StorageContext())
            {
                var listDto = storageContext.ProductGroups.Select(_mapper.Map<ProductGroupDto>).ToList();
            return listDto;
            }

        }
    }
}
