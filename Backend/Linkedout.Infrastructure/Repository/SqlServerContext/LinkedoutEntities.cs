using Linkedout.Domain.Users.Posts.Entities;
using Linkedout.Domain.Users.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Linkedout.Infrastructure.Repository.SqlServerContext
{
    public class LinkedoutEntities : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, UserRoleClaim, UserToken>, IDisposable
    {
        public LinkedoutEntities(DbContextOptions<LinkedoutEntities> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<UserRoleClaim>().ToTable("UserRoleClaim");
            modelBuilder.Entity<UserToken>().ToTable("UserToken");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Reaction>().ToTable("Reaction");
        }
    }
}
