using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Data.Migrations.ApplicationDb
{
    public partial class CorrectionManytoManyFollow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowersFollowed_User_FollowerUserId",
                table: "FollowersFollowed");

            migrationBuilder.DropIndex(
                name: "IX_FollowersFollowed_FollowerUserId",
                table: "FollowersFollowed");

            migrationBuilder.DropColumn(
                name: "FollowerUserId",
                table: "FollowersFollowed");

            migrationBuilder.CreateIndex(
                name: "IX_FollowersFollowed_FollowedId",
                table: "FollowersFollowed",
                column: "FollowedId");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowersFollowed_User_FollowedId",
                table: "FollowersFollowed",
                column: "FollowedId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowersFollowed_User_FollowedId",
                table: "FollowersFollowed");

            migrationBuilder.DropIndex(
                name: "IX_FollowersFollowed_FollowedId",
                table: "FollowersFollowed");

            migrationBuilder.AddColumn<string>(
                name: "FollowerUserId",
                table: "FollowersFollowed",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FollowersFollowed_FollowerUserId",
                table: "FollowersFollowed",
                column: "FollowerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowersFollowed_User_FollowerUserId",
                table: "FollowersFollowed",
                column: "FollowerUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
