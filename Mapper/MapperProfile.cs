using AutoMapper;
using ASPLec10Sem3GraphQL.Dto;
using ASPLec10Sem3GraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPLec10Sem3GraphQL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
            CreateMap<Storage, StorageDto>().ReverseMap();  //Добавил для ДЗ

        }
    }
}
