using ECommerce.Shared.Common;
using ECommerce.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Abstraction.IServices
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductQueryParams productQueryParams);
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();
        Task<ProductDto> GetByIdAsync(int id);
    }
}
