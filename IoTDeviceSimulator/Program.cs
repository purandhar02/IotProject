using IoTDeviceSimulator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSingleton<EventHubService>(sp =>
    new EventHubService(
        builder.Configuration["EventHub:ConnectionString"],
        builder.Configuration["EventHub:Name"]));

// Add controllers
builder.Services.AddControllers();
// Add Swagger services
builder.Services.AddSwaggerGen(); // Register Swagger services

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Enable Swagger
    app.UseSwaggerUI();  // Enable Swagger UI
}
app.MapControllers();
app.Run();
