using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project.BLL.Business;
using Project.BLL.Contracts;
using Project.DAL.Contracts;
using Project.DAL.Repositories;
using Project.Sevices.Mappings;
using Swashbuckle.AspNetCore.Swagger;

namespace Project.Sevices
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
            //capturar a string de conexão com o banco de dados
            var connectionString = Configuration.GetConnectionString("Desafio");

            //mapeamento da injeção de dependência
            //services.AddTransient<IPlanBusiness, PlanBusiness>();
            //services.AddTransient<IRegionBusiness, RegionBusiness>();
            //services.AddTransient<IPlanRepository, PlanRepository>(map => new PlanRepository(connectionString));
            //services.AddTransient<IRegionRepository, RegionRepository>(map => new RegionRepository(connectionString));
            services.AddScoped<IPlanBusiness, PlanBusiness>();
            services.AddScoped<IRegionBusiness, RegionBusiness>();
            services.AddScoped<IPlanRepository, PlanRepository>(map => new PlanRepository(connectionString));
            services.AddScoped<IRegionRepository, RegionRepository>(map => new RegionRepository(connectionString));

            //configurar o AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<EntityToViewModelMap>();
                cfg.AddProfile<ViewModelToEntityMap>();
            });



            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Desafio Wooza", Version = "v1" });

                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
                c.DocumentFilterDescriptors.AsReadOnly();
                c.CustomSchemaIds(i => i.FullName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Desafio Wooza");
                c.DefaultModelExpandDepth(0);
                c.DefaultModelsExpandDepth(-1);

            });
        }
    }
}
