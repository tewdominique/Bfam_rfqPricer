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
