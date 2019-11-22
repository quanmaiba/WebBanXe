using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBanXe.Migrations
{
    public partial class iy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TheLoaiXeId",
                table: "DongXes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DongXes_TheLoaiXeId",
                table: "DongXes",
                column: "TheLoaiXeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DongXes_TheLoaiXes_TheLoaiXeId",
                table: "DongXes",
                column: "TheLoaiXeId",
                principalTable: "TheLoaiXes",
                principalColumn: "TheLoaiXeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DongXes_TheLoaiXes_TheLoaiXeId",
                table: "DongXes");

            migrationBuilder.DropIndex(
                name: "IX_DongXes_TheLoaiXeId",
                table: "DongXes");

            migrationBuilder.DropColumn(
                name: "TheLoaiXeId",
                table: "DongXes");
        }
    }
}
