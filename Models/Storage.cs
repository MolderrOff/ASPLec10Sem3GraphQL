using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPLec10Sem3GraphQL.Models
{
    public class Storage
    {
        public int Id { get; set; }        
        public int Count { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        //public virtual Product Product { get; set; }
    }
}
