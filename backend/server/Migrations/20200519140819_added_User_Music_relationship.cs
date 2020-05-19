using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class added_User_Music_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Artist",
                table: "Music",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Music",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Music_UserId",
                table: "Music",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Music_AspNetUsers_UserId",
                table: "Music",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music_AspNetUsers_UserId",
                table: "Music");

            migrationBuilder.DropIndex(
                name: "IX_Music_UserId",
                table: "Music");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Music");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Music",
                newName: "Artist");
        }
    }
}
