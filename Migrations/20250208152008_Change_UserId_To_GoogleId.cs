using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyMapAPI.Migrations
{
    /// <inheritdoc />
    public partial class Change_UserId_To_GoogleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserGoogleId",
                table: "UserCounties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGoogleId",
                table: "UserCounties");
        }
    }
}
