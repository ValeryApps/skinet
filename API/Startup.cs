using API.Helpers;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.SeedData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
   public class Startup
   {
      private readonly IConfiguration _configuration;
      public Startup(IConfiguration configuration)
      {
         _configuration = configuration;
      }

      //public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddScoped<IProductRepository, ProductRepository>();
         services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
         services.AddDbContext<StoreContext>(opt => opt.UseSqlServer(_configuration["ConnectionStrings:DBCS"]));
         services.AddControllers();
         services.AddAutoMapper(typeof(AutoMapperProfiles));
         services.AddCors(opt =>
         {
            opt.AddPolicy("CorsPolicy", policy =>
            {
               policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
            });
         });
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseHttpsRedirection();

         app.UseRouting();
         app.UseStaticFiles();
         app.UseCors("CorsPolicy");

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
