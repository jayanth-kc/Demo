using Application.Activites;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationservices(this IServiceCollection services,IConfiguration config)
        {
             services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });

            // var conn = _config.GetConnectionString("DefaultConnection");
            //var sqLiteconn = new SQLiteConnection(conn);

            services.AddDbContext<DataContext>(Opt => {
                Opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors(opt=>{
                opt.AddPolicy("CorsPolicy", polcy=>{
                polcy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });      
            });

            services.AddMediatR(typeof(List.Handler).Assembly);

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}