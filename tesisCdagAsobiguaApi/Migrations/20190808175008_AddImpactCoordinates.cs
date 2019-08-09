using Microsoft.EntityFrameworkCore.Migrations;

namespace tesisCdagAsobiguaApi.Migrations
{
    public partial class AddImpactCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ImpactX",
                table: "Shots",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ImpactY",
                table: "Shots",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImpactX",
                table: "Shots");

            migrationBuilder.DropColumn(
                name: "ImpactY",
                table: "Shots");
        }
    }
}
