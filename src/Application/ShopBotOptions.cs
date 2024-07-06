namespace ShopBotNET.Application;

/// <summary>
/// The application options.
/// </summary>
public record ShopBotOptions
{
    public const string SectionName = "ShopBot";

    /// <summary>
    /// The webhook URL. If not set, the application url will be used instead if available.
    /// </summary>
    public string? WebhookUrl { get; set; }

    /// <summary>
    /// The secret token used to configure the webhook. If not set, if not set, the bot will use long polling.
    /// </summary>f
    public string? SecretToken { get; set; }

    /// <summary>
    /// The bot token provided by BotFather.
    /// </summary>
    public required string BotToken { get; set; }

    /// <summary>
    /// The payment provider token.
    /// </summary>
    public required string ProviderToken { get; set; }

    /// <summary>
    /// A custom endpoint where the bot will be sending requests instead of the default one (https://api.telegram.org).
    /// </summary>
    public string? ServerAddress { get; set; }
}
