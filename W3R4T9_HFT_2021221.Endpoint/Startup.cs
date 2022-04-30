using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Data;
using W3R4T9_HFT_2021221.Logic;
using W3R4T9_HFT_2021221.Repository;

namespace W3R4T9_HFT_2021221.Endpoint
{
    public class Startup
    {

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

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }


    }
}
