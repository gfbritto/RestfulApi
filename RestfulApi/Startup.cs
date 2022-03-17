using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using RestfulApi.Business.Implementations;
using RestfulApi.Business.Interfaces;
using RestfulApi.Repository.Implementations;
using RestfulApi.Repository.Interfaces;
using RestfulApi.Repository.Persistence;
using Microsoft.OpenApi.Models;
using System;
using RestfulApi.Models;
using Microsoft.AspNetCore.Rewrite;

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

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
                .AddXmlSerializerFormatters();

            services.AddApiVersioning();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = Constants.PROJECT_NAME,
                        Version = "v1",
                        Description = "API RESTful developed in coruse 'REST API's RESTFul do 0 à Azure com ASP.NET Core 5 e Docker'",
                        Contact = new OpenApiContact
                        {
                            Name = "Gabriel Brito",
                            Url = new Uri(Constants.SWAGGER_GITHUB_CONTACT)
                        }
                    });
            });

            services.AddScoped<IPersonBusiness, PersonBusiness>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<IBookBusiness, BookBusiness>();
            services.AddScoped<IBookRepository, BookRepository>();
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

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", Constants.PROJECT_NAME));

            var option =  new RewriteOptions();
            option.AddRedirect("^$","swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
