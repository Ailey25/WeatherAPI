using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherApp {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            // Instantiate
            WeatherData wd = new WeatherData();

            // var jsonStr = wd.CallByCityID("2172797").Result;
            var jsonStr = @"{""coord"":{""lon"":145.77,""lat"":-16.92},""weather"":[{""id"":802,""main"":""Clouds"",""description"":""scattered clouds"",""icon"":""03n""}],""base"":""stations"",""main"":{""temp"":299.15,""pressure"":1013,""humidity"":78,""temp_min"":299.15,""temp_max"":299.15},""visibility"":10000,""wind"":{""speed"":3.6,""deg"":150},""clouds"":{""all"":40},""dt"":1540243800,""sys"":{""type"":1,""id"":8166,""message"":0.0027,""country"":""AU"",""sunrise"":1540151036,""sunset"":1540196332},""id"":2172797,""name"":""Cairns"",""cod"":200}";

            var obj = wd.ParseWeatherDataObject(jsonStr);

            // DISPLAY
            app.Run(async (context) => {
                await context.Response.WriteAsync("Here's the JSON string:\n");
                await context.Response.WriteAsync(jsonStr + "\n");
                await context.Response.WriteAsync("----------\n");
                await context.Response.WriteAsync("Country name: " + obj.name.ToString());
                await context.Response.WriteAsync("\n");
            });
        }
    }
}
