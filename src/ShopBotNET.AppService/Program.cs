// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using ShopBotNET.AppService;
using ShopBotNET.Core;
using ShopBotNET.Core.Data;
using ShopBotNET.Core.Services;
using ShopBotNET.Infrastructure;
using ShopBotNET.Infrastructure.Data;

IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((context, services) =>
	{
		var configuration = context.Configuration;

		// Configure database context
		// var connectionString = configuration.GetConnectionString("Default");
		// services.AddDbContext<ShopBotContext>(options => options.UseSqlite(connectionString));

		// Configure cache context
		var cacheConnection = $"Data Source={Path.GetTempFileName()}"; // Get connection string for cache
		services.AddDbContext<CacheDbContext>(options => options.UseSqlite(cacheConnection));

		// Add bot properties service.
		services.AddSingleton<ShopBotProperties>();

		// Add Shop Data source
		services.AddScoped<IShopDb, ShopDb>();

		// Add bot service.
		services.AddScoped<ShopBot>();

		// Add long polling service
		services.AddHostedService<Worker>();
	})
	.Build();

// Create cache database file
using (var scope = host.Services.CreateScope())
{
	using var context = scope.ServiceProvider.GetRequiredService<CacheDbContext>();
	context.Database.EnsureCreated();
}

await host.RunAsync();
