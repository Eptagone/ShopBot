// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Core;
using ShopBotNET.Core.Services;
using Telegram.BotAPI;
using Telegram.BotAPI.GettingUpdates;

namespace ShopBotNET.AppService
{
    /// <summary>
    /// This service class is used to get updates via Long Polling.
    /// </summary>
    public class Worker : BackgroundService
    {
        private readonly BotClient _api;
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, ShopBotProperties botProperties, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _api = botProperties.Api;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            // Long Polling
            var updates = await _api.GetUpdatesAsync(cancellationToken: stoppingToken).ConfigureAwait(false);
            while (!stoppingToken.IsCancellationRequested)
            {
                if (updates.Any())
                {
                    Parallel.ForEach(updates, (update) => ProcessUpdate(update));

                    updates = await _api.GetUpdatesAsync(updates[^1].UpdateId + 1, cancellationToken: stoppingToken).ConfigureAwait(false);
                }
                else
                {
                    updates = await _api.GetUpdatesAsync(cancellationToken: stoppingToken).ConfigureAwait(false);
                }
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker stopping at: {time}", DateTimeOffset.Now);
            return base.StopAsync(cancellationToken);
        }

        private void ProcessUpdate(Update update)
        {
            using var scope = _serviceProvider.CreateScope();
            var bot = scope.ServiceProvider.GetRequiredService<ShopBot>();
            bot.OnUpdate(update);
        }
    }
}
