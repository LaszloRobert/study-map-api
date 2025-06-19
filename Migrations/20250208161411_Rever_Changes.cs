using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyMapAPI.Migrations
{
    /// <inheritdoc />
    public partial class Rever_Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGoogleId",
                table: "UserCounties");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserGoogleId",
                table: "UserCounties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
