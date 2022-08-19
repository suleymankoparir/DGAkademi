using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_03.Core.Entities
{
    public class Product : BaseEntity
    {
        public int DetailId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal PaidPrice { get; set; }
        public decimal Tax { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<Sale> Sales { get; set; }
        public List<ProductUserPermission> ProductUserPermissions { get; set; }
    }
}
