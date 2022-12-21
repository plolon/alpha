using CommandService.Extensions;
using CommandService.Persistence.Configuration;
using PlatformService.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureProfiles();
builder.Services.AddControllers();
builder.Services.ConfigureMessageBus();
builder.Services.ConfigureDataServices(builder.Configuration);
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
app.PreparePlatform();

app.Run();
