using DI_InAspNetCore_WebAPI.Interfaces;
using DI_InAspNetCore_WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register the services
builder.Services.AddSingleton<ISingletonService, OperationService>();
builder.Services.AddTransient<ITransientService, OperationService>();
builder.Services.AddScoped<IScopedService, OperationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
