using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.AddColumn<int>(
                name: "GroupeId",
                table: "User",
                nullable: true);

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
                    PosterUserId = table.Column<int>(nullable: true)
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
                    AdminUserId = table.Column<int>(nullable: true),
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
                    UserId = table.Column<int>(nullable: false),
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
                    UserId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "MyProperty",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyProperty", x => new { x.PostId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_MyProperty_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyProperty_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupeId",
                table: "User",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_AdminUserId",
                table: "Group",
                column: "AdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_AnnouncedPostPostId",
                table: "Group",
                column: "AnnouncedPostPostId");

            migrationBuilder.CreateIndex(
                name: "IX_HashtagPost_PostId",
                table: "HashtagPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_MyProperty_GroupId",
                table: "MyProperty",
                column: "GroupId");

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
                name: "FK_User_Group_GroupeId",
                table: "User");

            migrationBuilder.DropTable(
                name: "HashtagPost");

            migrationBuilder.DropTable(
                name: "MyProperty");

            migrationBuilder.DropTable(
                name: "PostLike");

            migrationBuilder.DropTable(
                name: "TaggedUserPosts");

            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropIndex(
                name: "IX_User_GroupeId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GroupeId",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Edited = table.Column<bool>(nullable: false),
                    StatusContent = table.Column<string>(nullable: false),
                    StatusPostDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                    table.ForeignKey(
                        name: "FK_Status_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Status_UserId",
                table: "Status",
                column: "UserId");
        }
    }
}
