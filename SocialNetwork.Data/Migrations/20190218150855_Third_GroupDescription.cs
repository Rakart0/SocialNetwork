using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Data.Migrations
{
    public partial class Third_GroupDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Group",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Group");
        }
    }
}
