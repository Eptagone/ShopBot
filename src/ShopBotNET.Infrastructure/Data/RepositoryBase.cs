// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using ShopBotNET.Core.Data;

namespace ShopBotNET.Infrastructure.Data
{
    public abstract class RepositoryBase<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class, new()
    {
        protected readonly TDbContext _context;
        public RepositoryBase(TDbContext context)
        {
            _context = context;
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return entity;
        }
    }
}
