// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using ShopBotNET.Core.Entities;

namespace ShopBotNET.Infrastructure
{
    /// <summary>Cache DB Context</summary>
    public partial class CacheDbContext : DbContext
    {
        /// <summary>Initialize a new instance of <see cref="CacheDbContext"/>.</summary>
        public CacheDbContext()
        {
        }

        /// <summary>Initialize a new instance of <see cref="CacheDbContext"/>.</summary>
        public CacheDbContext(DbContextOptions<CacheDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserState> States { get; set; }
        public virtual DbSet<DemoInvoice> DemoInvoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
