using Microsoft.EntityFrameworkCore.Migrations;

namespace Linkedout.Infrastructure.Migrations
{
    public partial class AddProfilePictureUrlToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallProfilePictureUrl",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SmallProfilePictureUrl",
                table: "User");
        }
    }
}
