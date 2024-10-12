using ASPLec10Sem3GraphQL.Abstraction;
using ASPLec10Sem3GraphQL.Data;
using ASPLec10Sem3GraphQL.Dto;
using ASPLec10Sem3GraphQL.Models;
using AutoMapper;
using System;
using System.Net.WebSockets;

namespace ASPLec10Sem3GraphQL.Repository
{

        public class StorageRepository : IStorageRepository //добавил для дз
        {
            StorageContext storageContext;
            private readonly IMapper _mapper;
            public StorageRepository(StorageContext storageContext, IMapper mapper)
            {
                this.storageContext = storageContext;
                this._mapper = mapper;
            }
            public int AddStorage(StorageDto storageDto)
            {
                if (storageContext.Storages.Any(s => s.Count == storageDto.Count))
                {
                    throw new Exception("Уже существует склад с таким номером");
                }
                else
                {
                    var entity = _mapper.Map<Storage>(storageDto);
                    storageContext.Storages.Add(entity);
                    storageContext.SaveChanges();
                    return entity.Id; //предлагал entity.Count


                }
            }
            public void DeleteStorage(int Id) 
            {
                throw new NotImplementedException();
            }
            public IEnumerable<StorageDto> GetAllStorages() 
            {
                using(storageContext = new StorageContext())
                {
                    var listDto = storageContext.Storages.Select(_mapper.Map<StorageDto>).ToList();
                    return listDto;
                }
            }

        }
    
}
