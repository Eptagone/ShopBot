# ShopBot

This is a Telegram bot imitation of [@ShopBot](https://t.me/ShopBot) made with NET 8.

This bot can do everything [@ShopBot](https://t.me/ShopBot) does, or well... almost everything. You won't be able to see the difference. If you're interested in how the Payment API works in Bots, this project can help you.

## How to Run: Long Polling

You just need to specify your **bot token** and your payment **provider token** in the `ShopBotNET.AppService` project.

The **provider token** allows your bot to use the payment API. If you don't already have it, you can get one for testing by creating an account on [stripe](https://stripe.com/) and [enabling TEST mode](https://stripe.com/). Then [go to BotFather and get your token](https://core.telegram.org/bots/payments#getting-a-token).

Your `secrets.json` or `appsettings.json` should look like the following code:

```JSON
{
"ShopBot": {
    "BotToken": "123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11",
    "ProviderToken": "123456789:TEST:XXXXXXXXXXXXXXXXX"
  }
}
```

You can also use enviroment variables instead:

| Env                      | Description                                                      |
| :----------------------- | :--------------------------------------------------------------- |
| ShopBot\_\_BotToken      | Your bot token provided by [@BotFather](https://t.me/BotFather). |
| ShopBot\_\_ProviderToken | Your provider token.                                             |

Finally, run `ShopBotNET.AppService` and see the magic.

## How to Run: Webhook

If you want to run this bot using a webhook, you must add two additional settings: the **application url** and a **secret token** in the `ShopBotNET.Webhook` project. Optionally, you can specify the **certificate** path to use with your webhook.

Your `secrets.json` or `appsettings.json` should look like the following code:

```JSON
{
  "ShopBot": {
    "WebhookUrl": "https://www.example.com",
    "BotToken": "123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11",
    "SecretToken": "SUPERSECRETTOKEN",
    "ProviderToken": "123456789:TEST:XXXXXXXXXXXXXXXXX"
  }
}
```

You can also use enviroment variables instead:

| Env                      | Description                                                      |
| :----------------------- | :--------------------------------------------------------------- |
| ShopBot\_\_WebhookUrl    | Your webhook url. Ex: <https://example.com>                      |
| ShopBot\_\_SecretToken   | Your webhook secret token. It must be specified by yourself.     |
| ShopBot\_\_BotToken      | Your bot token provided by [@BotFather](https://t.me/BotFather). |
| ShopBot\_\_ProviderToken | Your provider token.                                             |

Finally, run `ShopBotNET.Webhook` and see the magic.
