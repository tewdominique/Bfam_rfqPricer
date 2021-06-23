using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RfqParser.Domain;
using RfqParser.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;


namespace RfqParser
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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BfamRfqPricer API",
                    Description = "Bfam RfqParserPricer in ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Dominique TEW",
                        Email = "tewdominique@gmail.com",
                        Url = new Uri("https://github.com/tewdominique"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "RfqParser public repository",
                        Url = new Uri("https://github.com/tewdominique/Bfam_rfqPricer"),
                    }
                });
            });

            ConfigurePricer(services);

            ConfigureParser(services);
        }

        private void ConfigureParser(IServiceCollection services)
        {
            services.AddSingleton<RfqParser>();
        }

        private void ConfigurePricer(IServiceCollection services)
        {
            services.AddSingleton<IQuoteCalculationEngine, QuoteCalculationEngine>();
            services.AddSingleton<IReferencePriceSource, ReferencePriceSource>();
            services.AddSingleton<IReferencePriceSourceListener, ReferencePriceSourceListener>();
            services.AddSingleton<RfqPricerEngine>() ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //c.RoutePrefix = string.Empty;
            });

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
