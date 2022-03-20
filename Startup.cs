using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TMSAPI.Models;
using TMSAPI.Queries;
using TMSAPI.Repositories;

namespace TMSAPI
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
            var connection = Configuration.GetConnectionString("TMSDatabase");
            services.AddDbContextPool<TMSContext>(option => option.UseSqlServer(connection));
            services.AddControllers();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddCors(option =>
            option.AddPolicy(name: "CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountRoleRepository, AccountRoleRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ITaskListRepository, TaskListRepository>();
            services.AddTransient<ITransportsRepository, TransportsRepository>();
            services.AddTransient<ITMSQueries, TMSQueries>(sv => new TMSQueries(connection));

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
        }
    }
}
