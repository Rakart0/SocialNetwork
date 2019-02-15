using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.IdentityModels;

namespace Socialnetwork.Webclient.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FollowersFollowed> FollowersFollowed { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<GroupPost> GroupPosts { get; set; }
        public DbSet<HashtagPost> HashtagPost { get; set; }
        public DbSet<PostLike> PostLike { get; set; }
        public DbSet<TaggedUserPost> TaggedUserPosts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<FollowersFollowed>()
                .HasKey(ff => new { ff.FollowerId, ff.FollowedId });

            modelBuilder.Entity<FollowersFollowed>()
                .HasOne(fwr => fwr.Follower)
                .WithMany(f => f.Following)
                .HasForeignKey(fk => fk.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FollowersFollowed>()
                .HasOne(fwd => fwd.Followed)
                .WithMany(f => f.Followers)
                .HasForeignKey(fk => fk.FollowedId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<GroupPost>()
                .HasKey(gp => new { gp.PostId, gp.GroupId });

            modelBuilder.Entity<GroupPost>()
                .HasOne(g => g.Group)
                .WithMany(p => p.Posts)
                .HasForeignKey(fk => fk.GroupId);

            modelBuilder.Entity<GroupPost>()
                .HasOne(p => p.Post)
                .WithMany(g => g.TaggedGroups)
                .HasForeignKey(fk => fk.PostId);
           

            modelBuilder.Entity<User>()
                .HasMany(u => u.SubscribedGroups)
                .WithOne(g => g.Admin);

            modelBuilder.Entity<Group>()
                .HasOne(g => g.Admin)
                .WithMany(u => u.SubscribedGroups);

            modelBuilder.Entity<HashtagPost>()
                .HasKey(hp => new { hp.HashtagId, hp.PostId });

            modelBuilder.Entity<HashtagPost>()
                .HasOne(h => h.Hashtag)
                .WithMany(g => g.Posts)
                .HasForeignKey(fk => fk.HashtagId);

            modelBuilder.Entity<HashtagPost>()
                .HasOne(p => p.Post)
                .WithMany(h => h.Hashtag)
                .HasForeignKey(fk => fk.PostId);

            modelBuilder.Entity<PostLike>()
                .HasKey(pl => new { pl.PostId, pl.UserId });

            modelBuilder.Entity<PostLike>()
                .HasOne(p => p.Post)
                .WithMany(u => u.Likes)
                .HasForeignKey(u => u.PostId);

            modelBuilder.Entity<PostLike>()
                .HasOne(p => p.User)
                .WithMany(l => l.LikedPosts)
                .HasForeignKey(fk => fk.UserId);

            modelBuilder.Entity<TaggedUserPost>()
                .HasKey(k => new { k.UserId, k.PostId });

            modelBuilder.Entity<TaggedUserPost>()
                .HasOne(u => u.User)
                .WithMany(p => p.TaggedPosts)
                .HasForeignKey(fk => fk.UserId);


            modelBuilder.Entity<TaggedUserPost>()
                .HasOne(u => u.Post)
                .WithMany(p => p.TaggedPeople)
                .HasForeignKey(fk => fk.PostId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Responses)
                .WithOne(r => r.InResponseTo);

            modelBuilder.Entity<PostImage>()
                .HasKey(u => u.Url);
            modelBuilder.Entity<PostImage>()
                .HasOne(p => p.Post);
                
                



        }


    }
}