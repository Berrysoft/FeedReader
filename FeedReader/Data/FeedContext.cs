using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FeedReader.Data
{
#pragma warning disable 8618
    public class FeedContext : DbContext
    {
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<BlogPost> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=feeds.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().HasKey(post => new { post.FeedId, post.PostId });
        }
    }

    public class Feed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string FeedUri { get; set; }
        public string? ImageUri { get; set; }
        public string? Link { get; set; }
        public DateTime LastBuildDate { get; set; }
        public string? Generator { get; set; }
        public int Count { get; set; }
        public int RemainCount { get; set; }
    }

    public class BlogPost
    {
        public int FeedId { get; set; }
        public string PostId { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public string? Description { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime? LastReadTime { get; set; }
    }
#pragma warning restore 8618
}
