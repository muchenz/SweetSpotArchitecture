using OneReview.Controllers;
using OneReview.Persistence.Database;
using OneReview.Persistence.Repositories;
using OneReview.Services;
using System;

namespace OneReview.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {


        services.AddScoped<ProductService>();
        services.AddScoped<ReviewService>();



        return services; 
    }

    public static IServiceCollection AddPersistence(
       this IServiceCollection services, ConfigurationManager configuration)
    {

        services.AddScoped<IDbConnectionFactory, PgSqlConnectionFactory>(_ => 
        new PgSqlConnectionFactory(configuration[DbConstants.DefaultConnectionStringPath]!) );
        
        services.AddScoped<ProductsRepositoty>();



        return services;
    }

      public static IServiceCollection AddGlobalErrorHandling(
        this IServiceCollection services)
    {


        services.AddProblemDetails(optopns =>
        {
            optopns.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Extensions["asdf"] = "asdf";
            };
        });


        return services; 
    }
    
}