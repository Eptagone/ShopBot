// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Core;
using ShopBotNET.Core.Services;
using Telegram.BotAPI;
using Telegram.BotAPI.GettingUpdates;

namespace ShopBotNET.AppService;

/// <summary>
/// This service class is used to get updates via Long Polling.
/// </summary>
public class Worker(
    ILogger<Worker> logger,
    ShopBotProperties botProperties,
    IServiceProvider serviceProvider
) : BackgroundService
{
    private readonly ITelegramBotClient client = botProperties.Client;
    private readonly ILogger<Worker> logger = logger;
    private readonly IServiceProvider serviceProvider = serviceProvider;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        this.logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

        // Long Polling
        var updates = await this
            .client.GetUpdatesAsync(cancellationToken: stoppingToken)
            .ConfigureAwait(false);
        while (!stoppingToken.IsCancellationRequested)
        {
            if (updates.Any())
            {
                Parallel.ForEach(updates, (update) => this.ProcessUpdate(update));

                updates = await this
                    .client.GetUpdatesAsync(
                        updates.Last().UpdateId + 1,
                        cancellationToken: stoppingToken
                    )
                    .ConfigureAwait(false);
            }
            else
            {
                updates = await this
                    .client.GetUpdatesAsync(cancellationToken: stoppingToken)
                    .ConfigureAwait(false);
            }
        }
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Worker stopping at: {time}", DateTimeOffset.Now);
        return base.StopAsync(cancellationToken);
    }

    private void ProcessUpdate(Update update)
    {
        using var scope = this.serviceProvider.CreateScope();
        var bot = scope.ServiceProvider.GetRequiredService<ShopBot>();
        bot.OnUpdate(update);
    }
}
