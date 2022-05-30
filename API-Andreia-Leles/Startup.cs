using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using API_Andreia_Leles.Repository;
using API_Andreia_Leles.Repository.Interfaces;
using API_Andreia_Leles.Services;
using API_Andreia_Leles.Services.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace API_Andreia_Leles
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_Andreia_Leles", Version = "v1" });
            });
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddSingleton<IRecipeRepository, RecipeRepository>();

            services.AddCors(options => {
                options.AddPolicy(name: "MyPolicy",
                    policy => {
                        policy//.WithOrigins("http://localhost:8080").WithMethods("POST","GET","OPTIONS");
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                            //.SetIsOriginAllowed(CorsPolicy.IsOriginAllowed)
                            /*.SetIsOriginAllowedToAllowWildcardSubdomains().WithOrigins("http://*")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();*/
                    }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Andreia_Leles v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
