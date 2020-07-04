using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.specification;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ProductsController : ControllerBase
   {

      private readonly IGenericRepository<Product> _prod;
      private readonly IGenericRepository<ProductBrand> _brand;
      private readonly IGenericRepository<ProductType> _type;
      private readonly IMapper _mapper;

      public ProductsController(IGenericRepository<Product> prod, IGenericRepository<ProductBrand> brand, IGenericRepository<ProductType> type, IMapper mapper)
      {
         _type = type;
         _mapper = mapper;
         _brand = brand;
         _prod = prod;



      }
      [HttpGet]
      public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
      {
         var spec = new ProductsWithBrandandTypeSpec();
         var products = await _prod.ListAsync(spec);
         return Ok(_mapper.Map<IReadOnlyList<Product>, List<ProductToReturnDto>>(products));

      }
      [HttpGet("{id}")]
      public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
      {
         var spec = new ProductsWithBrandandTypeSpec(id);
         var product = await _prod.GetEntityWithSpec(spec);
         return _mapper.Map<Product, ProductToReturnDto>(product);

      }
      [HttpGet("brands")]
      public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrandAsync()
      {
         return Ok(await _brand.GetAllAsync());
      }
      [HttpGet("types")]
      public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypeAsync()
      {
         return Ok(await _type.GetAllAsync());
      }

   }
}