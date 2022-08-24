using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_03.Core.DTOs;

namespace W_03.Core.Views
{
    public class ProductAddView
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal PaidPrice { get; set; }
        public decimal Tax { get; set; }
        public List<PermissionAddDto> Permissions { get; set; }
    }
}
