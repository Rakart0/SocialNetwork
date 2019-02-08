using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Data.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_Group_GroupId",
                table: "MyProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_Post_PostId",
                table: "MyProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "GroupPosts");

            migrationBuilder.RenameIndex(
                name: "IX_MyProperty_GroupId",
                table: "GroupPosts",
                newName: "IX_GroupPosts_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupPosts",
                table: "GroupPosts",
                columns: new[] { "PostId", "GroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPosts_Group_GroupId",
                table: "GroupPosts",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPosts_Post_PostId",
                table: "GroupPosts",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupPosts_Group_GroupId",
                table: "GroupPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupPosts_Post_PostId",
                table: "GroupPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupPosts",
                table: "GroupPosts");

            migrationBuilder.RenameTable(
                name: "GroupPosts",
                newName: "MyProperty");

            migrationBuilder.RenameIndex(
                name: "IX_GroupPosts_GroupId",
                table: "MyProperty",
                newName: "IX_MyProperty_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                columns: new[] { "PostId", "GroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_Group_GroupId",
                table: "MyProperty",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_Post_PostId",
                table: "MyProperty",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
