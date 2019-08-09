using Microsoft.EntityFrameworkCore.Migrations;

namespace tesisCdagAsobiguaApi.Migrations
{
    public partial class AddXyzShotPositionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "XyzShotPosition",
                table: "XyzShots",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "XyzShotPosition",
                table: "XyzShots");
        }
    }
}
