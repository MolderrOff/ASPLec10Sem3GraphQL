using ASPLec10Sem3GraphQL.Dto;
using ASPLec10Sem3GraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPLec10Sem3GraphQL.Abstraction
{
    public interface IProductGroupRepository
    {
        IEnumerable<ProductGroupDto> GetAllProductGroups();
        int AddProductGroup(ProductGroupDto productGroupDto);
        void DeleteProductGroup(int id);
    }
}
