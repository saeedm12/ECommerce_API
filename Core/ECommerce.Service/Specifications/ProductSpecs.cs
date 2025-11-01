using ECommerce.Domain.Model.ProductModels;
using ECommerce.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Specifications
{
    public class ProductSpecs:BaseSpecs<Product,int>
    {
        public ProductSpecs(ProductQueryParams productQueryParams) :
            base(P=>(!productQueryParams.BrandId.HasValue || P.BrandId== productQueryParams.BrandId) && (!productQueryParams.TypeId.HasValue || P.TypeId== productQueryParams.TypeId)
            && (string.IsNullOrEmpty(productQueryParams.SearchValue)|| P.Name.ToLower().Contains(productQueryParams.SearchValue.ToLower())))
        {
            AddInclude(P=>P.Brand);
            AddInclude(P=>P.Type);

            switch (productQueryParams.SortingOption)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(P=>P.Name);
                    break;
                 case ProductSortingOptions.NameDesc:
                    AddOrderByDesc(P=>P.Name);
                    break;
                    case ProductSortingOptions.PriceAsc:
                    AddOrderBy(P=>P.Price);
                    break;
                    case ProductSortingOptions.PriceDesc:
                    AddOrderByDesc(P=>P.Price);
                    break;
                    default:
                    break;
            }
        }

        public ProductSpecs(int id) : base(P=>P.Id==id)
        {
            AddInclude(P => P.Brand);
            AddInclude(P => P.Type);
        }
    }
}
