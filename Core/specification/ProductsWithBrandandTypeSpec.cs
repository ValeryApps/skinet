using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.specification
{
   public class ProductsWithBrandandTypeSpec : Basespecification<Product>
   {
      public ProductsWithBrandandTypeSpec()
      {
         AddInclude(x => x.ProductBrand);
         AddInclude(x => x.ProductType);
      }

      public ProductsWithBrandandTypeSpec(int id) : base(x => x.Id == id)
      {
         AddInclude(x => x.ProductBrand);
         AddInclude(x => x.ProductType);
      }
   }
}