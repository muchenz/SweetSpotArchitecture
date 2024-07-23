// docker compose up --build

//docker compose down


using OneReview.DependencyInjection;
using OneReview.Persistence.Database;
using OneReview.RequestPipeline;
using OneReview.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddGlobalErrorHandling()
        .AddServices()
        .AddPersistence(builder.Configuration);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
     builder.Services.AddControllers();
 //   builder.Services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = true);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseGlobalErrorHandling();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.InitlizileDatadase();

    var a = app.Configuration["Database:ConnectionStrings:DefaultConnection"];

    Console.WriteLine("________"+a);

}
app.Run();

