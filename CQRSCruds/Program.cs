
using CQRSData;
using CQRSData.Data.context;
using CQRSData.Data.Mapper;
using CQRSData.Repos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSCruds
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<ICategoryRepos, CategoryRepos>();
            builder.Services.AddScoped<IProductRepos, ProductRepos>();
            builder.Services.AddMediatR(typeof(Lib).Assembly);
            builder.Services.AddAutoMapper(prof => prof.AddProfile(new ProductProfile()));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
