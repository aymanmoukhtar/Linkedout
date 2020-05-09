using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Linkedout.Infrastructure.Migrations
{
    public partial class changeReactionsColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reactions",
                table: "Post");

            migrationBuilder.AddColumn<int>(
                name: "ReactionsCount",
                table: "Post",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Comment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReactionsCount",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "Reactions",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
