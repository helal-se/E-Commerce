using Domain.Contracts;
using E_Commerce.Api.CustomMiddlewares;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Data.Seeding;
using Persistence.Repositories;
using Service.Abstraction;
using Service.Configurations;
using Service.Services;
using Shared.ErrorModels;

namespace E_Commerce.Api
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
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddAutoMapper(typeof(AssemblyReference).Assembly);

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var error = context.ModelState
                        .Where(e =>  e.Value?.Errors.Count > 0)
                        .Select(e => new ValidationError()
                        {
                            Field = e.Key,
                            Errors = e.Value?.Errors.Select(x => x.ErrorMessage)
                        });
                    var response = new ValidationResponse()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Errors = error
                    };
                    return new BadRequestObjectResult(response);
                };
            });
            var app = builder.Build();
            await InitializeDatabase();

            //------------------------------------------------------------
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            async Task InitializeDatabase()
            {
                using (var scope = app.Services.CreateScope())
                {
                    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                    await dbInitializer.InitializeAsync();
                }
            }
        }
    }
}
