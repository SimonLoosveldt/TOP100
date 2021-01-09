using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class RestructureMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHasTracks_Users_UserId",
                table: "UserHasTracks");

            migrationBuilder.DropColumn(
                name: "Album",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Tracks");

            migrationBuilder.RenameColumn(
                name: "manualEntry",
                table: "Tracks",
                newName: "ManualEntry");

            migrationBuilder.RenameColumn(
                name: "SpotifyId",
                table: "Tracks",
                newName: "SpotifyUri");

            migrationBuilder.RenameColumn(
                name: "ReleaseYear",
                table: "Tracks",
                newName: "ReleaseDate");

            migrationBuilder.AddColumn<string>(
                name: "SpotifyUri",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserHasTracks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserHasTracks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "UserHasTracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Tracks",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHasTracks",
                table: "UserHasTracks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpotifyUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_ArtistId",
                table: "Tracks",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Artist_ArtistId",
                table: "Tracks",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHasTracks_Users_UserId",
                table: "UserHasTracks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Artist_ArtistId",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHasTracks_Users_UserId",
                table: "UserHasTracks");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHasTracks",
                table: "UserHasTracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_ArtistId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "SpotifyUri",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserHasTracks");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "UserHasTracks");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Tracks");

            migrationBuilder.RenameColumn(
                name: "ManualEntry",
                table: "Tracks",
                newName: "manualEntry");

            migrationBuilder.RenameColumn(
                name: "SpotifyUri",
                table: "Tracks",
                newName: "SpotifyId");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Tracks",
                newName: "ReleaseYear");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserHasTracks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Album",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHasTracks_Users_UserId",
                table: "UserHasTracks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
