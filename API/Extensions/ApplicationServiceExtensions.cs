using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            /* builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(); */
            services.AddCors();

            //builder.Services.AddTransient();
            //builder.Services.AddSingleton();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}