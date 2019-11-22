using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBanXe.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaDiemTinhs",
                columns: table => new
                {
                    DiaDiemTinhId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenDiaDiemTinh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiemTinhs", x => x.DiaDiemTinhId);
                });

            migrationBuilder.CreateTable(
                name: "HangXes",
                columns: table => new
                {
                    HangXeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenHangXe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangXes", x => x.HangXeId);
                });

            migrationBuilder.CreateTable(
                name: "KmDaDis",
                columns: table => new
                {
                    KmDaDiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenKmDaDi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KmDaDis", x => x.KmDaDiId);
                });

            migrationBuilder.CreateTable(
                name: "LoaiXes",
                columns: table => new
                {
                    LoaiXeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenLoaiXe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiXes", x => x.LoaiXeId);
                });

            migrationBuilder.CreateTable(
                name: "MauXes",
                columns: table => new
                {
                    MauXeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenMauXe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauXes", x => x.MauXeId);
                });

            migrationBuilder.CreateTable(
                name: "PhanKhois",
                columns: table => new
                {
                    PhanKhoiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenPhanKhoi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanKhois", x => x.PhanKhoiId);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangs",
                columns: table => new
                {
                    TinhTrangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenTinhTrang = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangs", x => x.TinhTrangId);
                });

            migrationBuilder.CreateTable(
                name: "XuatXus",
                columns: table => new
                {
                    XuatXuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenXuatXu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XuatXus", x => x.XuatXuId);
                });

            migrationBuilder.CreateTable(
                name: "DiaDiemHuyens",
                columns: table => new
                {
                    DiaDiemHuyenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenDiaDiemHuyen = table.Column<string>(nullable: true),
                    DiaDiemTinhId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiemHuyens", x => x.DiaDiemHuyenId);
                    table.ForeignKey(
                        name: "FK_DiaDiemHuyens_DiaDiemTinhs_DiaDiemTinhId",
                        column: x => x.DiaDiemTinhId,
                        principalTable: "DiaDiemTinhs",
                        principalColumn: "DiaDiemTinhId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheLoaiXes",
                columns: table => new
                {
                    TheLoaiXeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenTheLoaiXe = table.Column<string>(nullable: true),
                    LoaiXeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoaiXes", x => x.TheLoaiXeId);
                    table.ForeignKey(
                        name: "FK_TheLoaiXes_LoaiXes_LoaiXeId",
                        column: x => x.LoaiXeId,
                        principalTable: "LoaiXes",
                        principalColumn: "LoaiXeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DongXes",
                columns: table => new
                {
                    DongXeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenDongXe = table.Column<string>(nullable: true),
                    HangXeId = table.Column<int>(nullable: false),
                    PhanKhoiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DongXes", x => x.DongXeId);
                    table.ForeignKey(
                        name: "FK_DongXes_HangXes_HangXeId",
                        column: x => x.HangXeId,
                        principalTable: "HangXes",
                        principalColumn: "HangXeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DongXes_PhanKhois_PhanKhoiId",
                        column: x => x.PhanKhoiId,
                        principalTable: "PhanKhois",
                        principalColumn: "PhanKhoiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoiXes",
                columns: table => new
                {
                    DoiXeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenDoiXe = table.Column<string>(nullable: true),
                    DongXeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoiXes", x => x.DoiXeId);
                    table.ForeignKey(
                        name: "FK_DoiXes_DongXes_DongXeId",
                        column: x => x.DongXeId,
                        principalTable: "DongXes",
                        principalColumn: "DongXeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    SanPhamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DongXeId = table.Column<int>(nullable: false),
                    TinhTrangId = table.Column<int>(nullable: false),
                    MauXeId = table.Column<int>(nullable: false),
                    XuatXuId = table.Column<int>(nullable: false),
                    KmDaDiId = table.Column<int>(nullable: false),
                    DiaDiemHuyenId = table.Column<int>(nullable: false),
                    GiaBan = table.Column<int>(nullable: false),
                    TieuDe = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    TenLienHe = table.Column<string>(nullable: true),
                    SDTLienHe = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.SanPhamId);
                    table.ForeignKey(
                        name: "FK_SanPhams_DiaDiemHuyens_DiaDiemHuyenId",
                        column: x => x.DiaDiemHuyenId,
                        principalTable: "DiaDiemHuyens",
                        principalColumn: "DiaDiemHuyenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_DongXes_DongXeId",
                        column: x => x.DongXeId,
                        principalTable: "DongXes",
                        principalColumn: "DongXeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_KmDaDis_KmDaDiId",
                        column: x => x.KmDaDiId,
                        principalTable: "KmDaDis",
                        principalColumn: "KmDaDiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_MauXes_MauXeId",
                        column: x => x.MauXeId,
                        principalTable: "MauXes",
                        principalColumn: "MauXeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_TinhTrangs_TinhTrangId",
                        column: x => x.TinhTrangId,
                        principalTable: "TinhTrangs",
                        principalColumn: "TinhTrangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_XuatXus_XuatXuId",
                        column: x => x.XuatXuId,
                        principalTable: "XuatXus",
                        principalColumn: "XuatXuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemHuyens_DiaDiemTinhId",
                table: "DiaDiemHuyens",
                column: "DiaDiemTinhId");

            migrationBuilder.CreateIndex(
                name: "IX_DoiXes_DongXeId",
                table: "DoiXes",
                column: "DongXeId");

            migrationBuilder.CreateIndex(
                name: "IX_DongXes_HangXeId",
                table: "DongXes",
                column: "HangXeId");

            migrationBuilder.CreateIndex(
                name: "IX_DongXes_PhanKhoiId",
                table: "DongXes",
                column: "PhanKhoiId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_DiaDiemHuyenId",
                table: "SanPhams",
                column: "DiaDiemHuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_DongXeId",
                table: "SanPhams",
                column: "DongXeId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_KmDaDiId",
                table: "SanPhams",
                column: "KmDaDiId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MauXeId",
                table: "SanPhams",
                column: "MauXeId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_TinhTrangId",
                table: "SanPhams",
                column: "TinhTrangId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_XuatXuId",
                table: "SanPhams",
                column: "XuatXuId");

            migrationBuilder.CreateIndex(
                name: "IX_TheLoaiXes_LoaiXeId",
                table: "TheLoaiXes",
                column: "LoaiXeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoiXes");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "TheLoaiXes");

            migrationBuilder.DropTable(
                name: "DiaDiemHuyens");

            migrationBuilder.DropTable(
                name: "DongXes");

            migrationBuilder.DropTable(
                name: "KmDaDis");

            migrationBuilder.DropTable(
                name: "MauXes");

            migrationBuilder.DropTable(
                name: "TinhTrangs");

            migrationBuilder.DropTable(
                name: "XuatXus");

            migrationBuilder.DropTable(
                name: "LoaiXes");

            migrationBuilder.DropTable(
                name: "DiaDiemTinhs");

            migrationBuilder.DropTable(
                name: "HangXes");

            migrationBuilder.DropTable(
                name: "PhanKhois");
        }
    }
}
