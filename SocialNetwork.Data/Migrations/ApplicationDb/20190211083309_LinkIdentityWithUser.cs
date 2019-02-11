using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Data.Migrations.ApplicationDb
{
    public partial class LinkIdentityWithUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    HashtagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HashtagName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.HashtagId);
                });

            migrationBuilder.CreateTable(
                name: "GroupPosts",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPosts", x => new { x.PostId, x.GroupId });
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    UserPictureUrl = table.Column<string>(nullable: true),
                    GroupeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowersFollowed",
                columns: table => new
                {
                    FollowerId = table.Column<string>(nullable: false),
                    FollowedId = table.Column<string>(nullable: false),
                    FollowerUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowersFollowed", x => new { x.FollowerId, x.FollowedId });
                    table.ForeignKey(
                        name: "FK_FollowersFollowed_User_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowersFollowed_User_FollowerUserId",
                        column: x => x.FollowerUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostContent = table.Column<string>(nullable: false),
                    PostTime = table.Column<DateTime>(nullable: false),
                    IsOriginalPost = table.Column<bool>(nullable: false),
                    OriginalPostPostId = table.Column<int>(nullable: true),
                    InResponseToPostId = table.Column<int>(nullable: true),
                    PosterUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_Post_InResponseToPostId",
                        column: x => x.InResponseToPostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Post_OriginalPostPostId",
                        column: x => x.OriginalPostPostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_User_PosterUserId",
                        column: x => x.PosterUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(maxLength: 50, nullable: false),
                    AdminUserId = table.Column<string>(nullable: true),
                    AnnouncedPostPostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupeId);
                    table.ForeignKey(
                        name: "FK_Group_User_AdminUserId",
                        column: x => x.AdminUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Group_Post_AnnouncedPostPostId",
                        column: x => x.AnnouncedPostPostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HashtagPost",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    HashtagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashtagPost", x => new { x.HashtagId, x.PostId });
                    table.ForeignKey(
                        name: "FK_HashtagPost_Hashtags_HashtagId",
                        column: x => x.HashtagId,
                        principalTable: "Hashtags",
                        principalColumn: "HashtagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HashtagPost_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostLike",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    Like = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLike", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PostLike_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostLike_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaggedUserPosts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaggedUserPosts", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_TaggedUserPosts_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaggedUserPosts_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowersFollowed_FollowerUserId",
                table: "FollowersFollowed",
                column: "FollowerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_AdminUserId",
                table: "Group",
                column: "AdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_AnnouncedPostPostId",
                table: "Group",
                column: "AnnouncedPostPostId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPosts_GroupId",
                table: "GroupPosts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HashtagPost_PostId",
                table: "HashtagPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_InResponseToPostId",
                table: "Post",
                column: "InResponseToPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_OriginalPostPostId",
                table: "Post",
                column: "OriginalPostPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_PosterUserId",
                table: "Post",
                column: "PosterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLike_UserId",
                table: "PostLike",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaggedUserPosts_PostId",
                table: "TaggedUserPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupeId",
                table: "User",
                column: "GroupeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPosts_Post_PostId",
                table: "GroupPosts",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPosts_Group_GroupId",
                table: "GroupPosts",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_GroupeId",
                table: "User",
                column: "GroupeId",
                principalTable: "Group",
                principalColumn: "GroupeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_User_AdminUserId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_PosterUserId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "FollowersFollowed");

            migrationBuilder.DropTable(
                name: "GroupPosts");

            migrationBuilder.DropTable(
                name: "HashtagPost");

            migrationBuilder.DropTable(
                name: "PostLike");

            migrationBuilder.DropTable(
                name: "TaggedUserPosts");

            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
