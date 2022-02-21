using AspNetCoreRateLimit;
using AspNetCoreRateLimit.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CorsAPI
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
            // services.AddCors(options =>
            // {
            //     options.AddPolicy("MyPolicy", builder =>
            //     {
            //         builder.WithOrigins("https://localhost:5001")
            //             .WithMethods("PUT", "GET", "DELETE");
            //     });
            //     options.AddPolicy("AllowAll", builder =>
            //     {
            //         builder.AllowAnyHeader()
            //             .AllowAnyMethod()
            //             .AllowAnyOrigin();
            //     });
            // });
            
            // needed to load configuration from appsettings.json
            services.AddOptions();

            // needed to store rate limit counters and ip rules
            services.AddMemoryCache();

            //load general configuration from appsettings.json
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            //load ip rules from appsettings.json
            services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));

            // inject counter and rules stores
            services.AddInMemoryRateLimiting();
            // services.AddDistributedRateLimiting<AsyncKeyLockProcessingStrategy>();
            // services.AddDistributedRateLimiting<RedisProcessingStrategy>();
            // services.AddRedisRateLimiting();
            
            // inject counter and rules distributed cache stores
            // services.AddSingleton<IIpPolicyStore, DistributedCacheIpPolicyStore>();
            // services.AddSingleton<IRateLimitCounterStore,DistributedCacheRateLimitCounterStore>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CorsAPI", Version = "v1" });
            });
            
            // configuration (resolvers, counter key builders)
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CorsAPI v1"));
            }
            
            app.UseIpRateLimiting();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // set 'AllowAll' policy as default
            // app.UseCors("AllowAll");
            // no default policy - restrict all access
            app.UseCors();
            // set 'MyPolicy' as default policy for all controllers and actions
            // app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
