using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_03.Core.Entities
{
    public class ProductUserPermission:BaseEntity
    {
        public int UserPermissionId { get; set; }
        public int ProductId { get; set; }
        public UserPermission UserPermission { get; set; }
        public Product Product { get; set; }
    }
}
