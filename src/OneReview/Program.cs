// docker compose up --build

//docker compose down


using OneReview.DependencyInjection;
using OneReview.Persistence.Database;

using OneReview.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddServices().AddPersistence(builder.Configuration);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();

    var a = app.Configuration["Database:ConnectionStrings:DefaultConnection"];

    Console.WriteLine("________"+a);

}
app.Run();

