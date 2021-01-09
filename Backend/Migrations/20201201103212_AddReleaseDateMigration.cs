using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class AddReleaseDateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Tracks");

            migrationBuilder.AddColumn<int>(
                name: "ReleaseDateInfo",
                table: "Tracks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReleaseDateInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDatePrecision = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseDateInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_ReleaseDateInfo",
                table: "Tracks",
                column: "ReleaseDateInfo",
                unique: true,
                filter: "[ReleaseDateInfo] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_ReleaseDateInfos_ReleaseDateInfo",
                table: "Tracks",
                column: "ReleaseDateInfo",
                principalTable: "ReleaseDateInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_ReleaseDateInfos_ReleaseDateInfo",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "ReleaseDateInfos");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_ReleaseDateInfo",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "ReleaseDateInfo",
                table: "Tracks");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
