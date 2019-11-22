using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBanXe.Migrations
{
    public partial class ui : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DoXe",
                table: "SanPhams",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MuaBan",
                table: "SanPhams",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoXe",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "MuaBan",
                table: "SanPhams");
        }
    }
}
