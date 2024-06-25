// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using ShopBotNET.Core.Data;

namespace ShopBotNET.Infrastructure.Data;

public abstract class RepositoryBase<TDbContext, TEntity> : IRepository<TEntity>
		where TDbContext : DbContext
		where TEntity : class, new()
{
	protected readonly TDbContext _context;
	public RepositoryBase(TDbContext context)
	{
		this._context = context;
	}

	public virtual void Delete(TEntity entity)
	{
		this._context.Entry(entity).State = EntityState.Deleted;
		this._context.SaveChanges();
	}

	public virtual TEntity Insert(TEntity entity)
	{
		this._context.Add(entity);
		this._context.SaveChanges();

		return entity;
	}

	public virtual TEntity Update(TEntity entity)
	{
		this._context.Entry(entity).State = EntityState.Modified;
		this._context.SaveChanges();

		return entity;
	}
}
