using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBanXe.Migrations
{
    public partial class iyii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoiXeDongXe_DoiXes_DoiXeId",
                table: "DoiXeDongXe");

            migrationBuilder.DropForeignKey(
                name: "FK_DoiXeDongXe_DongXes_DongXeId",
                table: "DoiXeDongXe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoiXeDongXe",
                table: "DoiXeDongXe");

            migrationBuilder.RenameTable(
                name: "DoiXeDongXe",
                newName: "DoiXeDongXes");

            migrationBuilder.RenameIndex(
                name: "IX_DoiXeDongXe_DongXeId",
                table: "DoiXeDongXes",
                newName: "IX_DoiXeDongXes_DongXeId");

            migrationBuilder.RenameIndex(
                name: "IX_DoiXeDongXe_DoiXeId",
                table: "DoiXeDongXes",
                newName: "IX_DoiXeDongXes_DoiXeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoiXeDongXes",
                table: "DoiXeDongXes",
                column: "DoiXeDongXeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoiXeDongXes_DoiXes_DoiXeId",
                table: "DoiXeDongXes",
                column: "DoiXeId",
                principalTable: "DoiXes",
                principalColumn: "DoiXeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoiXeDongXes_DongXes_DongXeId",
                table: "DoiXeDongXes",
                column: "DongXeId",
                principalTable: "DongXes",
                principalColumn: "DongXeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoiXeDongXes_DoiXes_DoiXeId",
                table: "DoiXeDongXes");

            migrationBuilder.DropForeignKey(
                name: "FK_DoiXeDongXes_DongXes_DongXeId",
                table: "DoiXeDongXes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoiXeDongXes",
                table: "DoiXeDongXes");

            migrationBuilder.RenameTable(
                name: "DoiXeDongXes",
                newName: "DoiXeDongXe");

            migrationBuilder.RenameIndex(
                name: "IX_DoiXeDongXes_DongXeId",
                table: "DoiXeDongXe",
                newName: "IX_DoiXeDongXe_DongXeId");

            migrationBuilder.RenameIndex(
                name: "IX_DoiXeDongXes_DoiXeId",
                table: "DoiXeDongXe",
                newName: "IX_DoiXeDongXe_DoiXeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoiXeDongXe",
                table: "DoiXeDongXe",
                column: "DoiXeDongXeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoiXeDongXe_DoiXes_DoiXeId",
                table: "DoiXeDongXe",
                column: "DoiXeId",
                principalTable: "DoiXes",
                principalColumn: "DoiXeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoiXeDongXe_DongXes_DongXeId",
                table: "DoiXeDongXe",
                column: "DongXeId",
                principalTable: "DongXes",
                principalColumn: "DongXeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
