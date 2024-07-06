using ShopBotNET.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddShopBotApplication(builder.Configuration);
var app = builder.Build();

app.MapControllers();

app.Run();
