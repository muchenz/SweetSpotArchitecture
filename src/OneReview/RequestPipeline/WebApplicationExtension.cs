using OneReview.Persistence.Database;

namespace OneReview.RequestPipeline;

public static class WebApplicationExtension
{
    public static WebApplication InitlizileDatadase(this WebApplication app)
    {
        DbInitializer.Initialize(app.Configuration[DbConstants.DefaultConnectionStringPath]!);

        return app;
    }
}
