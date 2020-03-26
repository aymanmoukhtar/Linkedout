using Linkedout.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Linkedout.Infrastructure.Repository.SqlServerContext
{
    public class LinkedoutEntities : DbContext, IDisposable
    {
        public LinkedoutEntities(DbContextOptions<LinkedoutEntities> options)
        : base(options)
        {
        }
        public DbSet<User> Users { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(_ => _.Id);
            });
        }
    }
}
