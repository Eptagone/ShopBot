// Copyright (c) 2024 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.GettingUpdates;

namespace ShopBotNET.Application;

/// <summary>
/// Represents a background service that sets up the ShopBot bot application.
/// </summary>
/// <param name="logger">The logger.</param>
/// <param name="client">The Telegram Bot API client.</param>
class ShopBotSetup(
    ILogger<ShopBotSetup> logger,
    ITelegramBotClient client,
    IOptions<ShopBotOptions> options
) : IHostedService
{
    /// <inheritdoc />
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogSettingUpBotCommands();

        // Delete my old commands
        client.DeleteMyCommands();
        // Set my commands
        client.SetMyCommands(
            [
                new("invoice", "Try out Telegram Payments"),
                new("terms", "Terms and Conditions"),
                new("support", "Leave Feedback")
            ]
        );

        logger.LogCommandsRegistered();

        // Delete webhook to use Long Polling
        client.DeleteWebhook();

        // Delete the previous webhook if it is configured.
        await client.DeleteWebhookAsync(cancellationToken: cancellationToken);

        var webhookUrl = options.Value.WebhookUrl;
        var secretToken = options.Value.SecretToken;

        // Setup the webhook if it is configured.
        if (!string.IsNullOrEmpty(webhookUrl) && !string.IsNullOrEmpty(secretToken))
        {
            logger.LogWebhookSetUp();
            await client.SetWebhookAsync(
                webhookUrl,
                secretToken: secretToken,
                cancellationToken: cancellationToken
            );
            logger.LogWebhookSetUpSuccessful(webhookUrl);
        }

        logger.LogSetupCompleted();
    }

    /// <inheritdoc />
    Task IHostedService.StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
