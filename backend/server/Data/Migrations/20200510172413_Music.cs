using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class Music : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "User_ID",
                table: "PlayList",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_UserPlayList_Music_ID",
                table: "UserPlayList",
                column: "Music_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlayList_Playlist_ID",
                table: "UserPlayList",
                column: "Playlist_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayList_User_ID",
                table: "PlayList",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayList_AspNetUsers_User_ID",
                table: "PlayList",
                column: "User_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlayList_Music_Music_ID",
                table: "UserPlayList",
                column: "Music_ID",
                principalTable: "Music",
                principalColumn: "Music_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlayList_PlayList_Playlist_ID",
                table: "UserPlayList",
                column: "Playlist_ID",
                principalTable: "PlayList",
                principalColumn: "PlayList_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayList_AspNetUsers_User_ID",
                table: "PlayList");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlayList_Music_Music_ID",
                table: "UserPlayList");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlayList_PlayList_Playlist_ID",
                table: "UserPlayList");

            migrationBuilder.DropIndex(
                name: "IX_UserPlayList_Music_ID",
                table: "UserPlayList");

            migrationBuilder.DropIndex(
                name: "IX_UserPlayList_Playlist_ID",
                table: "UserPlayList");

            migrationBuilder.DropIndex(
                name: "IX_PlayList_User_ID",
                table: "PlayList");

            migrationBuilder.AlterColumn<Guid>(
                name: "User_ID",
                table: "PlayList",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
