using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blog.MVC.Models;

namespace Blog.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PostTag>()
            .HasKey(t => new { t.PostID, t.TagID });

            builder.Entity<PostTag>()
                .HasOne(t => t.Post)
                .WithMany(t => t.PostTags)
                .HasForeignKey(t => t.PostID);

            builder.Entity<PostTag>()
                .HasOne(t => t.Tag)
                .WithMany(t => t.PostTag)
                .HasForeignKey(t => t.TagID);

            builder.Entity<Post>()
                .HasKey(t => t.ID);

            builder.Entity<Tag>()
                .HasKey(t => t.ID);

            builder.Entity<Lead>()
                .HasKey(t => t.ID);

            builder.Entity<Lead>()
                .HasAlternateKey(t => t.Email);


            base.OnModelCreating(builder);
        }
    }
}
