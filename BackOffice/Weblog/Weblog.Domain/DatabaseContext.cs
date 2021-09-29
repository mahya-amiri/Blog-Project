using Microsoft.EntityFrameworkCore;
using Weblog.Domain.Models;

namespace Weblog.Domain
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Article>()
            //    .HasOne<User>(a => a.User)
            //    .WithMany()
            //    .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Comment>()
                .HasOne<User>(c => c.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Children)
                .WithOne()
                .HasForeignKey(c => c.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email).IsUnique(true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Weblog_FuSoft");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}