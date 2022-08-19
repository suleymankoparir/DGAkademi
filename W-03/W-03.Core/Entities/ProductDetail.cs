using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_03.Core.Entities
{
    public class ProductDetail:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}
