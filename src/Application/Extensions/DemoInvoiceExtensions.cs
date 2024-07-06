// Copyright (c) 2024 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Application.Models;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.Extensions;
using MSG = ShopBotNET.Application.Resources.BotMessages;

namespace ShopBotNET.Application.Extensions;

public static class DemoInvoiceExtensions
{
    private const string HeavyCheckMark = "✔️ ";
    private const string RadioButton = "🔘";
    private const string WhiteCircle = "⚪️";

    /// <summary>
    /// Generate a reply markup for DemoInvoice builder.
    /// </summary>
    /// <param name="demoInvoice">Demo invoice configuration.</param>
    /// <returns>A <see cref="InlineKeyboardMarkup"/> object.</returns>
    public static InlineKeyboardMarkup GenInlineKeyboard(this DemoInvoice demoInvoice)
    {
        var needName = (demoInvoice.NeedName ? HeavyCheckMark : string.Empty) + MSG.Name;
        var needEmail = (demoInvoice.NeedEmail ? HeavyCheckMark : string.Empty) + MSG.Email;
        var needPhone = (demoInvoice.NeedPhone ? HeavyCheckMark : string.Empty) + MSG.Phone;
        var needShipping =
            (demoInvoice.NeedShippingAddress ? HeavyCheckMark : string.Empty) + MSG.Shipping;
        var sendPhoto = (demoInvoice.SendPhoto ? HeavyCheckMark : string.Empty) + MSG.Photo;
        var sendWebview = (demoInvoice.SendWebView ? HeavyCheckMark : string.Empty) + MSG.WebView;

        var usd = string.Format(
            "{0} USD",
            demoInvoice.Currency == CurrencyCodes.USD ? RadioButton : WhiteCircle
        );
        var eur = string.Format(
            "{0} EUR",
            demoInvoice.Currency == CurrencyCodes.EUR ? RadioButton : WhiteCircle
        );
        var jpy = string.Format(
            "{0} JPY",
            demoInvoice.Currency == CurrencyCodes.JPY ? RadioButton : WhiteCircle
        );
        var gbp = string.Format(
            "{0} GBP",
            demoInvoice.Currency == CurrencyCodes.GBP ? RadioButton : WhiteCircle
        );
        var irr = string.Format(
            "{0} IRR",
            demoInvoice.Currency == CurrencyCodes.IRR ? RadioButton : WhiteCircle
        );
        var uah = string.Format(
            "{0} UAH",
            demoInvoice.Currency == CurrencyCodes.UAH ? RadioButton : WhiteCircle
        );
        var inr = string.Format(
            "{0} INR",
            demoInvoice.Currency == CurrencyCodes.INR ? RadioButton : WhiteCircle
        );
        var aed = string.Format(
            "{0} AED",
            demoInvoice.Currency == CurrencyCodes.AED ? RadioButton : WhiteCircle
        );
        var rub = string.Format(
            "{0} RUB",
            demoInvoice.Currency == CurrencyCodes.RUB ? RadioButton : WhiteCircle
        );

        var buttons = new InlineKeyboardBuilder()
            .AppendCallbackData(needName, "switch needName")
            .AppendCallbackData(needEmail, "switch needEmail")
            .AppendRow()
            .AppendCallbackData(needPhone, "switch needPhone")
            .AppendCallbackData(needShipping, "switch needShipping")
            .AppendRow()
            .AppendCallbackData(sendPhoto, "switch sendPhoto")
            .AppendCallbackData(sendWebview, "switch sendWebview")
            .AppendRow()
            .AppendCallbackData(usd, "setCurrency USD")
            .AppendCallbackData(eur, "setCurrency EUR")
            .AppendCallbackData(jpy, "setCurrency JPY")
            .AppendRow()
            .AppendCallbackData(gbp, "setCurrency GBP")
            .AppendCallbackData(irr, "setCurrency IRR")
            .AppendCallbackData(uah, "setCurrency UAH")
            .AppendRow()
            .AppendCallbackData(inr, "setCurrency INR")
            .AppendCallbackData(aed, "setCurrency AED")
            .AppendCallbackData(rub, "setCurrency RUB")
            .AppendRow()
            .AppendCallbackData(MSG.SendInvoiceButton, "sendInvoice");

        return new InlineKeyboardMarkup(buttons);
    }
}
