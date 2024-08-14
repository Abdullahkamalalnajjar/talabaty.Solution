    using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using talabatyyy.Repository;
using talabatyyy.Repository.Data;
using talabatyyyy.Core.Repository;
using talabatyyyy.test.Errors;
using talabatyyyy.test.Helpers;
using talabatyyyy.test.Extentions;

namespace talabatyyyy.test
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            #region ConnectionDatabase
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
            });
            #endregion


            builder.Services.AddApplicationServices();


            var app = builder.Build();


            #region Update-Database
            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var ILoggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbContext = services.GetRequiredService<ApplicationDbContext>();
                await dbContext.Database.MigrateAsync();
                await DataSeedDbContext.SeedAsync(dbContext);
            }
            catch (Exception ex)
            {

                var logger = ILoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "ِan error Occured during apply the Migration");
            }

            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
               app.AddServicesSwagger();
            }

            //to use any file or resource ex:images
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
