using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Data;
using W3R4T9_HFT_2021221.EndPointNew.Services;
using W3R4T9_HFT_2021221.Logic;
using W3R4T9_HFT_2021221.Repository;

namespace W3R4T9_HFT_2021221.EndPointNew
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


            services.AddTransient<IAirlineLogic, AirlineLogic>();
            services.AddTransient<IFlightLogic, FlightLogic>();
            services.AddTransient<IPassengerLogic, PassengerLogic>();
            services.AddTransient<IFlightRepository, FlightRepository>();
            services.AddTransient<IAirLineRepository, AirlineRepository>();
            services.AddTransient<IPassengerRepository, PassengerReporitory>();
            services.AddTransient<DBContext, DBContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "W3R4T9_HFT_2021221.Endpoint", Version = "v1" });
            });
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "W3R4T9_HFT_2021221.Endpoint v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x => x
              .AllowCredentials()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .WithOrigins("http://localhost:51600"));




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
