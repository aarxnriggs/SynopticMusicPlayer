using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPlayer.Migrations
{
    public partial class MoveCoverArtColumnToAlbumModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverArt",
                table: "Songs");

            migrationBuilder.AddColumn<string>(
                name: "CoverArt",
                table: "Albums",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverArt",
                table: "Albums");

            migrationBuilder.AddColumn<string>(
                name: "CoverArt",
                table: "Songs",
                maxLength: 250,
                nullable: true);
        }
    }
}
