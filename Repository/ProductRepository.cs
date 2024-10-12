using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
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
    public class ProductRepository : IProductRepository //----StorageContext storageContext, 
    {
        StorageContext storageContext; //---
        IMapper _mapper;
        IMemoryCache _memoryCache;
        public ProductRepository(StorageContext storageContext, IMapper _mapper, IMemoryCache _memoryCache)
        { 
            this.storageContext = storageContext;
            this._mapper = _mapper;
            this._memoryCache = _memoryCache;
        }
        //private readonly IMapper _mapper;
        //public ProductRepository(StorageContext storageContext, IMapper mapper)
        //{
        //    this.storageContext = storageContext;
        //    this._mapper = mapper;
        //}

        public int AddProduct(ProductDto productDto)
        {
            using (storageContext = new())
            {
                if (storageContext.Products.Any(p => p.Name == productDto.Name))
                {
                throw new Exception("Уже существет продукт с таким именем");
                }

            var entity = _mapper.Map<Product>(productDto);
            storageContext.Products.Add(entity);
            storageContext.SaveChanges();
            return entity.Id;

            }

        }

        public void DeleteProduct(int d)
        {
            
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            using (storageContext = new())
            {
                if (_memoryCache.TryGetValue("products", out List<ProductDto> listDto)) return listDto;
                listDto = storageContext.Products.Select(_mapper.Map<ProductDto>).ToList();
                _memoryCache.Set("products", listDto, TimeSpan.FromMinutes(30));
                return listDto;
            }


        }
    }
}
