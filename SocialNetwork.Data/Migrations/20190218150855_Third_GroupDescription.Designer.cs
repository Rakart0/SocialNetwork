﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Socialnetwork.Webclient.Data;

namespace SocialNetwork.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190218150855_Third_GroupDescription")]
    partial class Third_GroupDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.FollowersFollowed", b =>
                {
                    b.Property<string>("FollowerId");

                    b.Property<string>("FollowedId");

                    b.HasKey("FollowerId", "FollowedId");

                    b.HasIndex("FollowedId");

                    b.ToTable("FollowersFollowed");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.Group", b =>
                {
                    b.Property<int>("GroupeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminUserId");

                    b.Property<int?>("AnnouncedPostPostId");

                    b.Property<string>("Description");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("GroupeId");

                    b.HasIndex("AdminUserId");

                    b.HasIndex("AnnouncedPostPostId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.GroupPost", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("GroupId");

                    b.HasKey("PostId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupPosts");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.GroupUser", b =>
                {
                    b.Property<int>("GroupId");

                    b.Property<string>("UserId");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.Hashtag", b =>
                {
                    b.Property<int>("HashtagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HashtagName");

                    b.HasKey("HashtagId");

                    b.ToTable("Hashtags");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.HashtagPost", b =>
                {
                    b.Property<int>("HashtagId");

                    b.Property<int>("PostId");

                    b.HasKey("HashtagId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("HashtagPost");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InResponseToPostId");

                    b.Property<bool>("IsOriginalPost");

                    b.Property<int?>("OriginalPostPostId");

                    b.Property<string>("PostContent")
                        .IsRequired();

                    b.Property<DateTime>("PostTime");

                    b.Property<string>("PosterUserId");

                    b.HasKey("PostId");

                    b.HasIndex("InResponseToPostId");

                    b.HasIndex("OriginalPostPostId");

                    b.HasIndex("PosterUserId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.PostImage", b =>
                {
                    b.Property<string>("Url")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PostId");

                    b.HasKey("Url");

                    b.HasIndex("PostId");

                    b.ToTable("PostImage");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.PostLike", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<string>("UserId");

                    b.Property<bool>("Like");

                    b.HasKey("PostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PostLike");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.TaggedUserPost", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("PostId");

                    b.HasKey("UserId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("TaggedUserPosts");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.User", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int?>("GroupeId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserPictureUrl");

                    b.HasKey("UserId");

                    b.HasIndex("GroupeId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.IdentityModels.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.FollowersFollowed", b =>
                {
                    b.HasOne("SocialNetwork.Data.Models.User", "Followed")
                        .WithMany("Followers")
                        .HasForeignKey("FollowedId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialNetwork.Data.Models.User", "Follower")
                        .WithMany("Following")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.Group", b =>
                {
                    b.HasOne("SocialNetwork.Data.Models.User", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminUserId");

                    b.HasOne("SocialNetwork.Data.Models.Post", "AnnouncedPost")
                        .WithMany()
                        .HasForeignKey("AnnouncedPostPostId");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.GroupPost", b =>
                {
                    b.HasOne("SocialNetwork.Data.Models.Group", "Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SocialNetwork.Data.Models.Post", "Post")
                        .WithMany("TaggedGroups")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.GroupUser", b =>
                {
                    b.HasOne("SocialNetwork.Data.Models.Group", "Group")
                        .WithMany("SubscribedUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SocialNetwork.Data.Models.User", "User")
                        .WithMany("SubscribedGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.HashtagPost", b =>
                {
                    b.HasOne("SocialNetwork.Data.Models.Hashtag", "Hashtag")
                        .WithMany("Posts")
                        .HasForeignKey("HashtagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SocialNetwork.Data.Models.Post", "Post")
                        .WithMany("Hashtag")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.Post", b =>
                {
                    b.HasOne("SocialNetwork.Data.Models.Post", "InResponseTo")
                        .WithMany("Responses")
                        .HasForeignKey("InResponseToPostId");

                    b.HasOne("SocialNetwork.Data.Models.Post", "OriginalPost")
                        .WithMany()
                        .HasForeignKey("OriginalPostPostId");

                    b.HasOne("SocialNetwork.Data.Models.User", "Poster")
                        .WithMany("Posts")
                        .HasForeignKey("PosterUserId");
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.PostImage", b =>
                {
                    b.HasOne("SocialNetwork.Data.Models.Post", "Post")
                        .WithMany("Images")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.PostLike", b =>
                {
                    b.HasOne("SocialNetwork.Data.Models.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SocialNetwork.Data.Models.User", "User")
                        .WithMany("LikedPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.TaggedUserPost", b =>
                {
                    b.HasOne("SocialNetwork.Data.Models.Post", "Post")
                        .WithMany("TaggedPeople")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SocialNetwork.Data.Models.User", "User")
                        .WithMany("TaggedPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SocialNetwork.Data.Models.User", b =>
                {
                    b.HasOne("SocialNetwork.Data.Models.Group")
                        .WithMany("Moderators")
                        .HasForeignKey("GroupeId");

                    b.HasOne("SocialNetwork.Data.Models.IdentityModels.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
