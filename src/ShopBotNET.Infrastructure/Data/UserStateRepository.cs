// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Core.Data;
using ShopBotNET.Core.Entities;

namespace ShopBotNET.Infrastructure.Data;

public sealed class UserStateRepository : RepositoryBase<CacheDbContext, UserState>, IUserStateRepository
{
	public UserStateRepository(CacheDbContext context) : base(context)
	{
	}

	public UserState? GetLastState(long chatId) => this._context.States.FirstOrDefault(s => s.ChatId == chatId);

	public override UserState Insert(UserState entity)
	{
		var oldState = this._context.States.FirstOrDefault(s => s.ChatId == entity.ChatId && s.Name == entity.Name);

		if (oldState != null)
		{
			this.Delete(oldState);
		}
		return base.Insert(entity);
	}
}
