// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.Extensions.Configuration;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.GettingUpdates;
using File = System.IO.File;

namespace ShopBotNET.Core
{
    /// <summary>
    /// This class defines all the necessary settings and properties for the bot to work. <br />
    /// The application uses a single instance of this class.
    /// </summary>
    public sealed class ShopBotProperties : IBotProperties
    {
        private readonly BotCommandHelper _commandHelper;

        public ShopBotProperties(IConfiguration configuration)
        {
            var telegram = configuration.GetSection("Telegram"); // JSON: "Telegram"
            var botToken = telegram["BotToken"]; // ENV: Telegram__BotToken, JSON: "Telegram:BotToken"

            Api = new BotClient(botToken);
            User = Api.GetMe();

            _commandHelper = new BotCommandHelper(this);

            var payments = telegram.GetSection("Payments"); // JSON: "Telegram:Payments"
            var providerToken = payments["ProviderToken"]; // ENV: Telegram__Payments__ProviderToken, JSON: "Telegram:Payments:ProviderToken"

            if (string.IsNullOrEmpty(providerToken))
            {
                throw new ArgumentNullException("Payments provider token can't be null.");
            }

            ProviderToken = providerToken;

            // Delete my old commands
            Api.DeleteMyCommands();
            // Set my commands
            Api.SetMyCommands(
                new BotCommand("invoice", "Try out Telegram Payments"),
                new BotCommand("terms", "Terms and Conditions"),
                new BotCommand("support", "Leave Feedback"));

            // Delete webhook to use Long Polling
            Api.DeleteWebhook();

            // Setup Webhook
            var applicationUrl = configuration["ApplicationUrl"]; // https://www.example.com
            var secretToken = telegram["WebhookToken"]; // https://www.example.com/bot/<token>

            // If applicationUrl and secretToken aren't null, then the bot will be configured to use a Webhook.
            // Otherwise, bot will still be able to use Long Polling.
            if (!string.IsNullOrEmpty(applicationUrl) && !string.IsNullOrEmpty(secretToken))
            {
                var webhookConfig = new SetWebhookArgs()
                {
                    Url = string.Format("{0}/bot/{1}", applicationUrl, secretToken)
                };

                // If a certificate was specified, it will be configured.
                var certPath = configuration["Certificate"];
                if (!string.IsNullOrEmpty(certPath))
                {
                    var certBytes = File.ReadAllBytes(certPath);
                    var filename = Path.GetFileName(certPath);
                    var cert = new InputFile(certBytes, filename);

                    webhookConfig.Certificate = cert;
                }

                Api.SetWebhook(webhookConfig);
            }
        }

        /// <summary>
        /// Payments provider token.
        /// </summary>
        public string ProviderToken { get; }
        public BotClient Api { get; }
        public User User { get; }

        IBotCommandHelper IBotProperties.CommandHelper => _commandHelper;
    }
}
