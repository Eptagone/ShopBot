using ShopBotNET.AppService;
using ShopBotNET.Application;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddShopBotApplication(builder.Configuration);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
