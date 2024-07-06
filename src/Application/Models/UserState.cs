// Copyright (c) 2024 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

namespace ShopBotNET.Application.Models;

/// <summary>
/// Represents a user state
/// </summary>
/// <param name="chatId"></param>
public class UserState(long chatId)
{
    /// <summary>
    /// Unique identifier for chat where bot is waiting a response.
    /// </summary>
    public long ChatId { get; set; } = chatId;
}
