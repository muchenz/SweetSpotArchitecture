using Microsoft.AspNetCore.Diagnostics;
using OneReview.Persistence.Database;

namespace OneReview.RequestPipeline;

public static class WebApplicationExtension
{
    public static WebApplication InitlizileDatadase(this WebApplication app)
    {
        DbInitializer.Initialize(app.Configuration[DbConstants.DefaultConnectionStringPath]!);

        return app;
    }

    public static WebApplication UseGlobalErrorHandling(this WebApplication app)
    {
        app.UseExceptionHandler("/error");

        app.Map("/error", (HttpContext httpContext) =>{

            var exception = httpContext.Features.Get<IExceptionHandlerFeature?>();

            if (exception is  null) {

                return Results.Problem();
            }


            return Results.Problem("form error");
        });
        return app;
    }
    
}
