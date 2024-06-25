// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.Extensions.Configuration;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.GettingUpdates;
using File = System.IO.File;

namespace ShopBotNET.Core;

/// <summary>
/// This class defines all the necessary settings and properties for the bot to work. <br />
/// The application uses a single instance of this class.
/// </summary>
public sealed class ShopBotProperties
{
    public ShopBotProperties(IConfiguration configuration)
    {
        var botToken = configuration[Config.BotToken]; // ENV: Telegram__BotToken, JSON: "Telegram:BotToken"

        if (string.IsNullOrEmpty(botToken))
        {
            throw new ArgumentNullException("Telegram bot token can't be null.");
        }

        this.Client = new TelegramBotClient(botToken);
        this.User = this.Client.GetMe();

        var providerToken = configuration[Config.ProviderToken]; // ENV: Telegram__Payments__ProviderToken, JSON: "Telegram:Payments:ProviderToken"

        if (string.IsNullOrEmpty(providerToken))
        {
            throw new ArgumentNullException("Payments provider token can't be null.");
        }

        this.ProviderToken = providerToken;

        // Delete my old commands
        this.Client.DeleteMyCommands();
        // Set my commands
        this.Client.SetMyCommands(
            [
                new("invoice", "Try out Telegram Payments"),
                new("terms", "Terms and Conditions"),
                new("support", "Leave Feedback")
            ]
        );

        // Delete webhook to use Long Polling
        this.Client.DeleteWebhook();

        // Setup Webhook
        var applicationUrl = configuration[Config.ApplicationUrl]; // https://www.example.com
        var secretToken = configuration[Config.SecretToken]; // https://www.example.com/bot/<token>

        // If applicationUrl and secretToken aren't null, then the bot will be configured to use a Webhook.
        // Otherwise, bot will still be able to use Long Polling.
        if (!string.IsNullOrEmpty(applicationUrl) && !string.IsNullOrEmpty(secretToken))
        {
            var url = string.Format("{0}/bot", applicationUrl);
            var webhookConfig = new SetWebhookArgs(url) { SecretToken = secretToken };

            // If a certificate was specified, it will be configured.
            var certPath = configuration[Config.Certificate];
            if (!string.IsNullOrEmpty(certPath))
            {
                var certBytes = File.ReadAllBytes(certPath);
                var filename = Path.GetFileName(certPath);
                var cert = new InputFile(certBytes, filename);

                webhookConfig.Certificate = cert;
            }

            this.Client.SetWebhook(webhookConfig);
        }
    }

    /// <summary>
    /// Payments provider token.
    /// </summary>
    public string ProviderToken { get; }
    public TelegramBotClient Client { get; }
    public User User { get; }
}
