namespace WebBanXe.Models
{
    public class SanPham
    {
        public int SanPhamId { get; set; }

        public int DongXeId { get; set; }
        public DongXe DongXe { get; set; }

        public int TinhTrangId { get; set; }
        public TinhTrang TinhTrang { get; set; }

        public int MauXeId { get; set; }
        public MauXe MauXe { get; set; }

        public int XuatXuId { get; set; }
        public XuatXu XuatXu { get; set; }

        public int KmDaDiId { get; set; }
        public KmDaDi KmDaDi { get; set; }

        public int DiaDiemHuyenId { get; set; }
        public DiaDiemHuyen DiaDiemHuyen { get; set; }


        public int GiaBan { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string TenLienHe { get; set; }
        public string SDTLienHe { get; set; }
        public string Img { get; set; }

        public bool DoXe { get; set; }
        public bool MuaBan { get; set; }

    }
}
