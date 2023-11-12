using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIConfiguration.Configuration.Swagger
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfig( this IServiceCollection services, IConfiguration configuration )
        {

            services.AddEndpointsApiExplorer ();
            services.AddSwaggerGen ();
            return services;
        }

        public static IApplicationBuilder UseSwaggerImpl( this IApplicationBuilder app)
        {
            app.UseSwagger ();
            app.UseSwaggerUI (options =>
            {
                options.SwaggerEndpoint ("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
