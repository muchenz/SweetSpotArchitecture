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
}