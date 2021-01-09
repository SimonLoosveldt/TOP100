using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class Migration01_12_2020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Artist_ArtistId",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHasTracks_Tracks_TrackId",
                table: "UserHasTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHasTracks_Users_UserId",
                table: "UserHasTracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHasTracks",
                table: "UserHasTracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.RenameTable(
                name: "UserHasTracks",
                newName: "ListEntries");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Artists");

            migrationBuilder.RenameIndex(
                name: "IX_UserHasTracks_UserId",
                table: "ListEntries",
                newName: "IX_ListEntries_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserHasTracks_TrackId",
                table: "ListEntries",
                newName: "IX_ListEntries_TrackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListEntries",
                table: "ListEntries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListEntries_Tracks_TrackId",
                table: "ListEntries",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListEntries_Users_UserId",
                table: "ListEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListEntries_Tracks_TrackId",
                table: "ListEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_ListEntries_Users_UserId",
                table: "ListEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListEntries",
                table: "ListEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.RenameTable(
                name: "ListEntries",
                newName: "UserHasTracks");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artist");

            migrationBuilder.RenameIndex(
                name: "IX_ListEntries_UserId",
                table: "UserHasTracks",
                newName: "IX_UserHasTracks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ListEntries_TrackId",
                table: "UserHasTracks",
                newName: "IX_UserHasTracks_TrackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHasTracks",
                table: "UserHasTracks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Artist_ArtistId",
                table: "Tracks",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHasTracks_Tracks_TrackId",
                table: "UserHasTracks",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHasTracks_Users_UserId",
                table: "UserHasTracks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
