// Copyright (c) 2024 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.Extensions.Caching.Memory;
using ShopBotNET.Application.Models;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.Extensions;
using MSG = ShopBotNET.Application.Resources.BotMessages;

namespace ShopBotNET.Application.Services;

/// <summary>
/// It contains the main functionality of the telegram bot. <br />
/// The application creates a new instance of this class to process each update received.
/// </summary>
partial class ShopBot : SimpleTelegramBotBase
{
    private void OnUserState(Message message, UserState state)
    {
        if (string.IsNullOrEmpty(message.Text))
        {
            this.client.SendMessage(message.Chat.Id, MSG.SupportInvalid);
        }
        else
        {
            this.client.SendMessage(message.Chat.Id, MSG.SupportResult);
            this.RemoveState(state);
        }
    }

    private UserState? GetCurrentState(long chatId) =>
        this.cache.Get<UserState>($"UserState:{chatId}");

    private void CreateOrUpdateState(UserState state)
    {
        var key = $"UserState:{state.ChatId}";
        this.cache.Set(key, state, TimeSpan.FromMinutes(30));
    }

    private void RemoveState(UserState state)
    {
        var key = $"UserState:{state.ChatId}";
        this.cache.Remove(key);
    }
}
