using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.specification
{
   public class ProductsWithBrandandTypeSpec : Basespecification<Product>
   {
      public ProductsWithBrandandTypeSpec(ProductSpecParams productParams)
      : base(x =>
       (string.IsNullOrEmpty(productParams.Search) || x.Name.Contains(productParams.Search)) &&
       (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
       (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
      {
         AddInclude(x => x.ProductBrand);
         AddInclude(x => x.ProductType);
         AddOrderBy(x => x.Name);
         ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

         if (!string.IsNullOrEmpty(productParams.sort))
         {
            switch (productParams.sort)
            {
               case "priceAsc":
                  AddOrderBy(x => x.Price);
                  break;
               case "descending":
                  AddOrderByDescending(x => x.Price);
                  break;
               default:
                  AddOrderBy(x => x.Name);
                  break;
            }
         }

      }

      public ProductsWithBrandandTypeSpec(int id) : base(x => x.Id == id)
      {
         AddInclude(x => x.ProductBrand);
         AddInclude(x => x.ProductType);
      }
   }
}