using AvoidsCommunication.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidsCommunication.DAL
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rambling> Ramblings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(builder =>
            {
                builder.ToTable("Comments").HasKey(x => x.CommentId);

                builder.Property(x => x.CommentId).ValueGeneratedOnAdd();

                builder.Property(x => x.CommentText).HasMaxLength(200).IsRequired(true);
            });

            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Name).HasMaxLength(100).IsRequired(true);

                builder.Property(x => x.Password).IsRequired(false);

            });

            modelBuilder.Entity<Rambling>(builder =>
            {
                builder.ToTable("Ramblings").HasKey(x => x.RamblingId);

                builder.Property(x => x.RamblingId).ValueGeneratedOnAdd();

                builder.Property(x => x.Name).HasMaxLength(100).IsRequired(true);

                builder.Property(x => x.CreatedDate).IsRequired(true);

                builder.Property(x => x.Cover).IsRequired(false);

                builder.Property(x => x.Content).IsRequired(true);

                builder.Property(x => x.Topic).IsRequired(true);
            });
        }
    }
}
