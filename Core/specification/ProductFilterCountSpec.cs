using Core.Entities;

namespace Core.specification
{
   public class ProductFilterCountSpec : Basespecification<Product>
   {
      public ProductFilterCountSpec(ProductSpecParams productParams)
            : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
      {
      }
   }
}