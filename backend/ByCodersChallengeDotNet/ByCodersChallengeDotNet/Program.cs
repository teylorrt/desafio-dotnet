
using ByCodersChallengeDotNet.Application.Services;
using ByCodersChallengeDotNet.Core.Repositories;
using ByCodersChallengeDotNet.Core.Services;
using ByCodersChallengeDotNet.Infrastructure.DbContext;
using ByCodersChallengeDotNet.Infrastructure.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ByCodersChallengeDotNet
{
    public class Program
    {
        private const string CorsPolicy = "AllowAnyOriginPolicy";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                .AddTransient<IDbContext, DapperDbContext>()
                .AddTransient<IOperationRepository, OperationRepository>()
                .AddTransient<IOperationService, OperationService>();

            builder.Services.AddHealthChecks(); // Registers basic health check services

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            app.MapHealthChecks("/health"); // Exposes a /health endpoint

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseCors(CorsPolicy);

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
