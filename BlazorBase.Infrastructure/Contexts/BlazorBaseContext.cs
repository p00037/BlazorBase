using BlazorBase.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorBase.Infrastructure.Contexts
{
    public class BlazorBaseContext : DbContext
    {
        public BlazorBaseContext() : base()
        {
        }

        public BlazorBaseContext(DbContextOptions<BlazorBaseContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M_事業所DbEntity>().ToTable("M_事業所").HasKey(c => new { c.事業所番号 });
            modelBuilder.Entity<M_事業所明細DbEntity>().ToTable("M_事業所明細").HasKey(c => new { c.事業所番号,c.連番 });
            modelBuilder.Entity<M_ログインユーザーDbEntity>().ToTable("M_ログインユーザー").HasKey(c => new { c.UserName });
        }
    }
}