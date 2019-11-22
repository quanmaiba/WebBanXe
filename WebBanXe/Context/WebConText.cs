using Microsoft.EntityFrameworkCore;
using WebBanXe.Models;

namespace WebBanXe.Context
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {

        }

        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DiaDiemHuyen> DiaDiemHuyens { get; set; }
        public DbSet<DiaDiemTinh> DiaDiemTinhs { get; set; }
        public DbSet<DoiXeDongXe> DoiXeDongXes { get; set; }
        public DbSet<DoiXe> DoiXes { get; set; }
        public DbSet<DongXe> DongXes { get; set; }
        public DbSet<HangXe> HangXes { get; set; }
        public DbSet<KmDaDi> KmDaDis { get; set; }
        public DbSet<LoaiXe> LoaiXes { get; set; }
        public DbSet<PhanKhoi> PhanKhois { get; set; }
        public DbSet<MauXe> MauXes { get; set; }
        public DbSet<TheLoaiXe> TheLoaiXes { get; set; }
        public DbSet<TinhTrang> TinhTrangs { get; set; }
        public DbSet<XuatXu> XuatXus { get; set; }
    }
}
