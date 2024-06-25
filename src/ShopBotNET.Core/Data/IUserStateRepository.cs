// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Core.Entities;

namespace ShopBotNET.Core.Data;

public interface IUserStateRepository : IRepository<UserState>
{
	/// <summary>
	/// Retrive the last user state from a chat.
	/// </summary>
	/// <param name="chatId">Unique chat identifier from the chat.</param>
	/// <returns>An <see cref="UserState"/> instance. Can be null if there's not any user state for the specified chat.</returns>
	public UserState? GetLastState(long chatId);
}
