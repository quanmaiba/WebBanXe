using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBanXe.Migrations
{
    public partial class iyi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoiXes_DongXes_DongXeId",
                table: "DoiXes");

            migrationBuilder.DropIndex(
                name: "IX_DoiXes_DongXeId",
                table: "DoiXes");

            migrationBuilder.DropColumn(
                name: "DongXeId",
                table: "DoiXes");

            migrationBuilder.AddColumn<string>(
                name: "IMG",
                table: "HangXes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DoiXeDongXe",
                columns: table => new
                {
                    DoiXeDongXeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DongXeId = table.Column<int>(nullable: false),
                    DoiXeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoiXeDongXe", x => x.DoiXeDongXeId);
                    table.ForeignKey(
                        name: "FK_DoiXeDongXe_DoiXes_DoiXeId",
                        column: x => x.DoiXeId,
                        principalTable: "DoiXes",
                        principalColumn: "DoiXeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoiXeDongXe_DongXes_DongXeId",
                        column: x => x.DongXeId,
                        principalTable: "DongXes",
                        principalColumn: "DongXeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoiXeDongXe_DoiXeId",
                table: "DoiXeDongXe",
                column: "DoiXeId");

            migrationBuilder.CreateIndex(
                name: "IX_DoiXeDongXe_DongXeId",
                table: "DoiXeDongXe",
                column: "DongXeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoiXeDongXe");

            migrationBuilder.DropColumn(
                name: "IMG",
                table: "HangXes");

            migrationBuilder.AddColumn<int>(
                name: "DongXeId",
                table: "DoiXes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DoiXes_DongXeId",
                table: "DoiXes",
                column: "DongXeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoiXes_DongXes_DongXeId",
                table: "DoiXes",
                column: "DongXeId",
                principalTable: "DongXes",
                principalColumn: "DongXeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
