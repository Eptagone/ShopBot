# ShopBot

This is a Telegram bot imitation of [@ShopBot](https://t.me/ShopBot) made with NET 6.

This bot can do everything [@ShopBot](https://t.me/ShopBot) does, or well... almost everything. You won't be able to see the difference. If you're interested in how payment bots work, this project can help you.

## How to Run

You just need to specify your **bot token** and your payment **provider token** in the `ShopBotNET.AppService` project.

The **provider token** allows your bot to use the payment API. If you don't already have it, you can get one for testing by creating an account on [stripe](https://stripe.com/) and [enabling TEST mode](https://stripe.com/). Then [go to BotFather and get your token](https://core.telegram.org/bots/payments#getting-a-token).

Your `secrets.json` or `appsettings.json` should look like the following code:

```JSON
{
"Telegram": {
    "BotToken": "123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11",
    "Payments": {
      "ProviderToken": "123456789:TEST:XXXXXXXXXXXXXXXXX"
    }
  }
}
```

You can also use enviroment variables instead:

| Env                               | Description                                                      |
| :-------------------------------- | :--------------------------------------------------------------- |
| Telegram__BotToken                | Your bot token provided by [@BotFather](https://t.me/BotFather). |
| Telegram__Payments__ProviderToken | Your provider token.                                             |

Finally, run `ShopBotNET.AppService` and see the magic.
