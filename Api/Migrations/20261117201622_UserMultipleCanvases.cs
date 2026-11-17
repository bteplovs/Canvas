using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class UserMultipleCanvases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Canvases_UserId",
                table: "Canvases");

            migrationBuilder.CreateIndex(
                name: "IX_Canvases_UserId",
                table: "Canvases",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Canvases_UserId",
                table: "Canvases");

            migrationBuilder.CreateIndex(
                name: "IX_Canvases_UserId",
                table: "Canvases",
                column: "UserId",
                unique: true);
        }
    }
}
