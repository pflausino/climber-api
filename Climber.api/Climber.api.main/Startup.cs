using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Climber.api.main.Infra;
using Climber.api.main.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Climber.api.main
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
            services.Configure<ClimberDatabaseSettings>(
                Configuration.GetSection(nameof(ClimberDatabaseSettings)));

            services.AddSingleton<IClimberstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ClimberDatabaseSettings>>().Value);

            services.AddSingleton<PersonService>();
            services.AddSingleton<SkillService>();

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Enable CORS
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });
        }

        //Enable Cors

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("EnableCORS");

            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
        }
    }


    public class CamealCaseJsonProfileFormatter : JsonOutputFormatter
    {
        public CamealCaseJsonProfileFormatter() : base(new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }, ArrayPool<char>.Shared)
        {
            SupportedMediaTypes.Clear();
            
        }
    }
}
