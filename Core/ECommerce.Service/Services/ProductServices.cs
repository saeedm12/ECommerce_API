using AutoMapper;
using ECommerce.Abstraction.IServices;
using ECommerce.Domain.Contracts.UOW;
using ECommerce.Domain.Model.ProductModels;
using ECommerce.Service.Specifications;
using ECommerce.Shared.Common;
using ECommerce.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class ProductServices(IUnitOfWork unitOfWork,IMapper mapper ): IProductServices
    {

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductQueryParams productQueryParams)
        {
          var Spec = new ProductSpecs(productQueryParams);
          var Products = await unitOfWork.GetRepo<Product,int>().GetAllWithSpecsAsync(Spec);
          return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);

        }
       
        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var Spec = new ProductSpecs(id);
            var Products = await unitOfWork.GetRepo<Product, int>().GetByIdWithSpecsAsync(Spec);
            return mapper.Map<Product,ProductDto>(Products);
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
           var Repo = unitOfWork.GetRepo<ProductBrand,int>();
           var Brands = await Repo.GetAllAsync(); 
           var BrandsDto = mapper.Map<IEnumerable<ProductBrand> , IEnumerable<BrandDto>>(Brands);
            return BrandsDto;

        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var Types = await unitOfWork.GetRepo<ProductType, int>().GetAllAsync();
           return mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
            
        }

       
    }
}
