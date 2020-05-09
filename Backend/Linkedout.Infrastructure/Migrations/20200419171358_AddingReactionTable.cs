using Microsoft.EntityFrameworkCore.Migrations;

namespace Linkedout.Infrastructure.Migrations
{
    public partial class AddingReactionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Comment_CommentId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Post_PostId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CommentId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PostId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CommentsCount",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "Reactions",
                table: "Post",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Reactions",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReactorId = table.Column<string>(nullable: true),
                    ReactionType = table.Column<int>(nullable: false),
                    ReactOnId = table.Column<int>(nullable: false),
                    ReactOnType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reaction_User_ReactorId",
                        column: x => x.ReactorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_ReactorId",
                table: "Reaction",
                column: "ReactorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reaction");

            migrationBuilder.DropColumn(
                name: "Reactions",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Reactions",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentsCount",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_CommentId",
                table: "User",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PostId",
                table: "User",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Comment_CommentId",
                table: "User",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Post_PostId",
                table: "User",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
