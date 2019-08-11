using Microsoft.EntityFrameworkCore.Migrations;

namespace tesisCdagAsobiguaApi.Migrations
{
    public partial class AddTipSteerDirColumToShot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipSteerDir",
                table: "Shots",
                maxLength: 2,
                nullable: false,
                defaultValue: "C");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipSteerDir",
                table: "Shots");
        }
    }
}
