// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Core.Entities;
using IKB = Telegram.BotAPI.AvailableTypes.InlineKeyboardButton;
using IKM = Telegram.BotAPI.AvailableTypes.InlineKeyboardMarkup;
using MSG = ShopBotNET.Core.Resources.BotMessages;

namespace ShopBotNET.Core.Extensions
{
    public static class DemoInvoiceExtensions
    {
        private const string HeavyCheckMark = "✔️ ";
        private const string RadioButton = "🔘";
        private const string WhiteCircle = "⚪️";

        /// <summary>
        /// Generate a reply markup for DemoInvoice builder.
        /// </summary>
        /// <param name="demoInvoice">Demo invoice configuration.</param>
        /// <returns>A <see cref="IKM"/> object.</returns>
        public static IKM GenInlineKeyboard(this DemoInvoice demoInvoice)
        {
            var needName = (demoInvoice.NeedName ? HeavyCheckMark : string.Empty) + MSG.Name;
            var needEmail = (demoInvoice.NeedEmail ? HeavyCheckMark : string.Empty) + MSG.Email;
            var needPhone = (demoInvoice.NeedPhone ? HeavyCheckMark : string.Empty) + MSG.Phone;
            var needShipping = (demoInvoice.NeedShippingAddress ? HeavyCheckMark : string.Empty) + MSG.Shipping;
            var sendPhoto = (demoInvoice.SendPhoto ? HeavyCheckMark : string.Empty) + MSG.Photo;
            var sendWebview = (demoInvoice.SendWebView ? HeavyCheckMark : string.Empty) + MSG.WebView;

            var usd = string.Format("{0} USD", demoInvoice.Currency == CurrencyCodes.USD ? RadioButton : WhiteCircle);
            var eur = string.Format("{0} EUR", demoInvoice.Currency == CurrencyCodes.EUR ? RadioButton : WhiteCircle);
            var jpy = string.Format("{0} JPY", demoInvoice.Currency == CurrencyCodes.JPY ? RadioButton : WhiteCircle);
            var gbp = string.Format("{0} GBP", demoInvoice.Currency == CurrencyCodes.GBP ? RadioButton : WhiteCircle);
            var irr = string.Format("{0} IRR", demoInvoice.Currency == CurrencyCodes.IRR ? RadioButton : WhiteCircle);
            var uah = string.Format("{0} UAH", demoInvoice.Currency == CurrencyCodes.UAH ? RadioButton : WhiteCircle);
            var inr = string.Format("{0} INR", demoInvoice.Currency == CurrencyCodes.INR ? RadioButton : WhiteCircle);
            var aed = string.Format("{0} AED", demoInvoice.Currency == CurrencyCodes.AED ? RadioButton : WhiteCircle);
            var rub = string.Format("{0} RUB", demoInvoice.Currency == CurrencyCodes.RUB ? RadioButton : WhiteCircle);

            var buttons = new IKB[][]
            {
                new IKB[]
                {
                    IKB.SetCallbackData(needName, "switch needName"),
                    IKB.SetCallbackData(needEmail, "switch needEmail")
                },
                new IKB[]
                {
                    IKB.SetCallbackData(needPhone, "switch needPhone"),
                    IKB.SetCallbackData(needShipping, "switch needShipping")
                },
                new IKB[]
                {
                    IKB.SetCallbackData(sendPhoto, "switch sendPhoto"),
                    IKB.SetCallbackData(sendWebview, "switch sendWebview")
                },
                new IKB[]
                {
                    IKB.SetCallbackData(usd, "setCurrency USD"),
                    IKB.SetCallbackData(eur, "setCurrency EUR"),
                    IKB.SetCallbackData(jpy, "setCurrency JPY")
                },
                new IKB[]
                {
                    IKB.SetCallbackData(gbp, "setCurrency GBP"),
                    IKB.SetCallbackData(irr, "setCurrency IRR"),
                    IKB.SetCallbackData(uah, "setCurrency UAH")
                },
                new IKB[]
                {
                    IKB.SetCallbackData(inr, "setCurrency INR"),
                    IKB.SetCallbackData(aed, "setCurrency AED"),
                    IKB.SetCallbackData(rub, "setCurrency RUB")
                },
                new IKB[]
                {
                    IKB.SetCallbackData(MSG.SendInvoiceButton, "sendInvoice")
                }
            };

            return new IKM(buttons);
        }
    }
}
