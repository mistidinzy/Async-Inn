using System;
using Async_Inn.Data;
using Async_Inn.Models.Identity;
using Async_Inn.Services;
using Async_Inn.Services.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AsyncInn
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Dbcontext registered in ConfigureServices
            services.AddDbContext<AsyncInnDbContext>(options =>
           {
               string connectionString = Configuration.GetConnectionString("DefaultConnection");
               options.UseSqlServer(connectionString);
           });

            //Enable the use of MVC controllers in your ConfigureServices method
            services.AddControllers();

            //Add repository/services

            services.AddScoped<IRoomRepository, DatabaseRoomRepository>();

            services.AddSwaggerGen(options =>
            {
                //Make sure to get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Async Inn",
                    Version = "v1",
                });
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                //There are other options like this
            })

            .AddEntityFrameworkStores<AsyncInnDbContext>();
            services.AddTransient<IUserService, IdentityUserService>();
        }

        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
              app.UseDeveloperExceptionPage();
            }

            //Add explicit routing of Controllers in your ‘Configure’ method
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                //Create a new get route to prove that it works (i.e. /hey)
                endpoints.MapGet("/hi", () => "Hello!");

                //Alter this route to throw an exception instead of a response
                endpoints.MapGet("/500", context =>
                {
                  throw new ApplicationException("Boom!");
                });

                app.UseSwaggerUI(options => {
                    options.SwaggerEndpoint("/api/v1/swagger.json", "Async Inn");
                    options.RoutePrefix = "docs";
                });
            });
        }
    }
}
