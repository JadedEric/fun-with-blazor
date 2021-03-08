using BlazorApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp.Context
{
    public class BlazorAppDbContext: DbContext
    {
        public virtual DbSet<Objective> Objectives { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Respondent> Respondents { get; set; }

        public virtual DbSet<Result> Results { get; set; }

        public BlazorAppDbContext(DbContextOptions<BlazorAppDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(entity => entity.Entity is Entity &&
                    (entity.State == EntityState.Added || entity.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((Entity)entry.Entity).UpdatedBy = 1;
                ((Entity)entry.Entity).UpdatedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    ((Entity)entry.Entity).CreatedBy = 1;
                    ((Entity)entry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return SaveChangesAsync(true, cancellationToken);
        }
    }
}
