// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Core.Extensions;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableMethods.FormattingOptions;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.Payments;
using Telegram.BotAPI.UpdatingMessages;
using MSG = ShopBotNET.Core.Resources.BotMessages;

namespace ShopBotNET.Core.Services
{
    /// <summary>
    /// It contains the main functionality of the telegram bot. <br />
    /// The application creates a new instance of this class to process each update received.
    /// </summary>
    public partial class ShopBot : TelegramBotBase<ShopBotProperties>
    {
        protected override void OnCallbackQuery(CallbackQuery cQuery)
        {
            var args = cQuery.Data.Split(' ');
            if (cQuery.Message == null)
            {
                Api.AnswerCallbackQuery(cQuery.Id, "This button is no longer available", true, cacheTime: 99999);
                return;
            }
            var demoInvoice = _db.DemoInvoices.GetConfiguration(cQuery.Message.Chat.Id, cQuery.Message.MessageId);
            if (demoInvoice == null)
            {
                Api.AnswerCallbackQuery(cQuery.Id, "This button is no longer available", true, cacheTime: 99999);
                return;
            }

            void UpdateDemoInvoice()
            {
                Api.AnswerCallbackQuery(cQuery.Id, cacheTime: 5);

                var keyboard = demoInvoice.GenInlineKeyboard();
                Api.EditMessageReplyMarkup(new EditMessageReplyMarkup
                {
                    ChatId = cQuery.Message.Chat.Id,
                    MessageId = cQuery.Message.MessageId,
                    ReplyMarkup = keyboard
                });

                _db.DemoInvoices.Update(demoInvoice);
            }

            switch (args[0])
            {
                case "switch":
                    {
                        switch (args[1])
                        {
                            case "needName":
                                demoInvoice.NeedName = !demoInvoice.NeedName;
                                break;
                            case "needEmail":
                                demoInvoice.NeedEmail = !demoInvoice.NeedEmail;
                                break;
                            case "needPhone":
                                demoInvoice.NeedPhone = !demoInvoice.NeedPhone;
                                break;
                            case "needShipping":
                                demoInvoice.NeedShippingAddress = !demoInvoice.NeedShippingAddress;
                                break;
                            case "sendPhoto":
                                demoInvoice.SendPhoto = !demoInvoice.SendPhoto;
                                break;
                            case "sendWebview":
                                demoInvoice.SendWebView = !demoInvoice.SendWebView;
                                break;
                            default:
                                Api.AnswerCallbackQuery(cQuery.Id, "???", cacheTime: 999);
                                return;
                        }
                        UpdateDemoInvoice();
                    }
                    break;
                case "setCurrency":
                    demoInvoice.Currency = Enum.Parse<CurrencyCodes>(args[1], true);
                    UpdateDemoInvoice();
                    break;
                case "sendInvoice":
                    {
                        Api.AnswerCallbackQuery(cQuery.Id, cacheTime: 2);
                        Api.EditMessageText(cQuery.Message.Chat.Id, cQuery.Message.MessageId, MSG.DemoInvoiceResult, ParseMode.HTML, replyMarkup: null);

                        const string productName = "Working Time Machine";
                        const string description = "Want to visit your great-great-great-grandparents? Make a fortune at the races? Shake hands with Hammurabi and take a stroll in the Hanging Gardens? Order our Working Time Machine today!";

                        var prices = new LabeledPrice[]
                        {
                            new LabeledPrice("Subtotal", 12345),
                            new LabeledPrice("Handling", 5431),
                            new LabeledPrice("Discount", -3454)
                        };

                        var invoice = new SendInvoiceArgs(cQuery.Message.Chat.Id, productName, description, "WorkingTimeMachine", Properties.ProviderToken, demoInvoice.Currency.ToString(), prices)
                        {
                            // ProviderData = demoInvoice.SendWebView ? "<Your provider data to use WebView>" : null,
                            NeedName = demoInvoice.NeedName,
                            NeedEmail = demoInvoice.NeedEmail,
                            NeedPhoneNumber = demoInvoice.NeedPhone,
                            NeedShippingAddress = demoInvoice.NeedShippingAddress,
                            IsFlexible = demoInvoice.NeedShippingAddress,
                            StartParameter = "buy_tshirt"
                        };
                        if (demoInvoice.SendPhoto)
                        {
                            const string photoUrl = "https://telegra.ph/file/a242b4418901347c47be6.jpg";
                            invoice.PhotoUrl = photoUrl;
                            invoice.PhotoSize = 51488;
                            invoice.PhotoHeight = 490;
                            invoice.PhotoWidth = 640;
                        }

                        try
                        {
                            Api.SendInvoice(invoice);
                        }
                        catch (BotRequestException exp)
                        {
                            var error = string.Format(MSG.SendInvoiceError, exp.Message);
                            Api.SendMessage(cQuery.Message.Chat.Id, error, ParseMode.HTML);
                        }

                        _db.DemoInvoices.Delete(demoInvoice);
                    }
                    break;
                default:
                    Api.AnswerCallbackQuery(cQuery.Id, "???", cacheTime: 999);
                    break;
            }
        }
    }
}
