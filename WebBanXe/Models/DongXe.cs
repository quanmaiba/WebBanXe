using System.Collections.Generic;

namespace WebBanXe.Models
{
    public class DongXe
    {
        public int DongXeId { get; set; }
        public string TenDongXe { get; set; }

        public int HangXeId { get; set; }
        public HangXe HangXe { get; set; }

        public int PhanKhoiId { get; set; }
        public PhanKhoi PhanKhoi { get; set; }

        public int TheLoaiXeId { get; set; }
        public TheLoaiXe TheLoaiXe { get; set; }



        public IEnumerable<DoiXeDongXe> DoiXes { get; set; }
        public IEnumerable<SanPham> SanPhams { get; set; }
    }
}
