using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestfulApi.Business.Implementations;
using RestfulApi.Business.Interfaces;
using RestfulApi.Repository.Generic;
using RestfulApi.Repository.Persistence;

namespace RestfulApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("RestfulContext");

            services.AddControllers();

            services.AddDbContext<RestfulApiDbContext>(options =>
                options.UseSqlServer(connection));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddApiVersioning();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IPersonBusiness, PersonBusiness>();

            services.AddScoped<IBookBusiness, BookBusiness>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
