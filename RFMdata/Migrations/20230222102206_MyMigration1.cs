using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFM.Data.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoviesId",
                table: "Moviesvote",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moviesvote_MoviesId",
                table: "Moviesvote",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moviesvote_Movies_MoviesId",
                table: "Moviesvote",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moviesvote_Movies_MoviesId",
                table: "Moviesvote");

            migrationBuilder.DropIndex(
                name: "IX_Moviesvote_MoviesId",
                table: "Moviesvote");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "Moviesvote");
        }
    }
}
