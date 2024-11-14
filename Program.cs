using ECommerse_App.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// for appsettings.json file access...
var configuration = builder.Configuration;

builder.Services.AddSingleton<MongoDbContext>(sp =>
{
    string connectionUri = configuration.GetSection("ConnectionStrings:connectionUri").Value; // Adjust if needed
    string databaseName = configuration.GetSection("ConnectionStrings:databaseName").Value;

    return new MongoDbContext(connectionUri, databaseName);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


// swagger run url
// http://localhost:4201/swagger
// http://localhost:4201/swagger/index.html