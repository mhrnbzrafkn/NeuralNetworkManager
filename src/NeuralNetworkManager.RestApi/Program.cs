using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NeuralNetworkManager.Repositories.NeuralNetworks;
using NeuralNetworkManager.Services.NeuralNetworks;
using NeuralNetworkManager.Services.NeuralNetworks.Contracts;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace NeuralNetworkManager.RestApi;

public class Program
{
    private const string _moduleTitle = "Shop";

    public static void Main(string[] args)
    {
        // Set environment
        SetEnvironment();

        var builder = WebApplication.CreateBuilder(args);

        // Register modules
        RegisterModules(builder);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "docs/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "docs";
                options.DocumentTitle = $"{_moduleTitle} API Documentation";
                options.DocExpansion(DocExpansion.None);
            });
        }

        if (app.Environment.IsProduction())
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void RegisterModules(WebApplicationBuilder webBuilder)
    {
        // Register neural network service
        webBuilder.Services.AddTransient<NeuralNetworkService, NeuralNetworkAppService>();
        // Register neural network repository
        webBuilder.Services.AddTransient<NeuralNetworkRepository, NeuralNetworkJsonRepository>();
    }

    private static void SetEnvironment()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
    }
}