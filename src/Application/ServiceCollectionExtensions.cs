using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ShopBotNET.Application.Services;
using Telegram.BotAPI;

namespace ShopBotNET.Application;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add the required services for the main application
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddShopBotApplication(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<ShopBotOptions>(
            configuration.GetRequiredSection(ShopBotOptions.SectionName)
        );

        services.AddSingleton<ITelegramBotClient>(
            (provider) =>
            {
                var options = provider.GetRequiredService<IOptions<ShopBotOptions>>().Value;
                var botOptions = new TelegramBotClientOptions(options.BotToken);
                // Set a custom server address if specified
                if (!string.IsNullOrEmpty(options.ServerAddress))
                {
                    botOptions.ServerAddress = options.ServerAddress;
                }
                var client = new TelegramBotClient(botOptions);
                return client;
            }
        );

        services.AddMemoryCache();

        services.AddSingleton<IProductService, ProductService>();
        services.AddSingleton<IShippingService, ShippingService>();
        services.AddScoped<ShopBot>();

        services.AddSingleton<IUpdateReceiver, UpdateReceiver>();

        // Register the update receiver as a hosted service.
        services.AddHostedService(provider =>
            (UpdateReceiver)provider.GetRequiredService<IUpdateReceiver>()
        );
        services.AddHostedService<ShopBotSetup>();

        return services;
    }
}
