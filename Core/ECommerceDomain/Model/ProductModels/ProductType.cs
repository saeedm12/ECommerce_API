using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Model.ProductModels
{
    public class ProductType:BaseEntity<int>
    {
        public string Name { get; set; } = null!;

        //public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
