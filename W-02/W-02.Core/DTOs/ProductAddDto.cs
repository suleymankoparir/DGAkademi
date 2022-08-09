using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_02.Core.DTOs
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
