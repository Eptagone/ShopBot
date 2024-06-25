// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

namespace ShopBotNET.Core.Data;

public interface IRepository<TEntity>
		where TEntity : class, new()
{
	TEntity Insert(TEntity entity);
	TEntity Update(TEntity entity);
	void Delete(TEntity entity);
}
