using PlatformService.Extensions;
using PlatformService.Persistence.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence(builder.Configuration, builder.Environment);
builder.Services.ConfigureHttpClient(builder.Configuration);
builder.Services.ConfigureMessageBus();
builder.Services.ConfigureProfiles();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.PreparePlatform(app.Environment.IsProduction());

app.Run();
