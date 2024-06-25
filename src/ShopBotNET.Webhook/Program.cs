// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using ShopBotNET.Core;
using ShopBotNET.Core.Data;
using ShopBotNET.Core.Services;
using ShopBotNET.Infrastructure;
using ShopBotNET.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure cache context
var cacheConnection = $"Data Source={Path.GetTempFileName()}"; // Get connection string for cache
builder.Services.AddDbContext<CacheDbContext>(options => options.UseSqlite(cacheConnection));

// Add bot properties service.
builder.Services.AddSingleton<ShopBotProperties>();

// Add Shop Data source
builder.Services.AddScoped<IShopDb, ShopDb>();

// Add bot service.
builder.Services.AddScoped<ShopBot>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	// Create cache file
	using var context = scope.ServiceProvider.GetRequiredService<CacheDbContext>();
	context.Database.EnsureCreated();

	// Make sure ShopBotProperties is working.
	_ = scope.ServiceProvider.GetRequiredService<ShopBotProperties>();
}

// Configure the HTTP request pipeline.

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
	ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

if (!app.Environment.IsDevelopment())
{
	app.UseHsts();
	app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
