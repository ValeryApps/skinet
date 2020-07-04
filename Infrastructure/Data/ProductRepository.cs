using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
   public class ProductRepository : IProductRepository
   {
      private readonly StoreContext _context;
      public ProductRepository(StoreContext context)
      {
         _context = context;
      }

      public async Task<Product> GetProductAsync(int id)
      {
         return await _context.Products
         .Include(p => p.ProductBrand)
         .Include(t => t.ProductType)
         .FirstOrDefaultAsync(x => x.Id == id);
      }

      public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
      {
         return await _context.ProductBrands.ToListAsync();
      }

      public async Task<IReadOnlyList<Product>> GetProductsAsync()
      {
         return await _context.Products
         .Include(p => p.ProductBrand)
         .Include(t => t.ProductType)
         .ToListAsync();
      }

      public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
      {
         return await _context.ProductTypes.ToListAsync();
      }
   }
}