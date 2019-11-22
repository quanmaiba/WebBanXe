using System.Collections.Generic;

namespace WebBanXe.Models
{
    public class TinhTrang
    {
        public int TinhTrangId { get; set; }
        public string TenTinhTrang { get; set; }


        public IEnumerable<SanPham> SanPhams { get; set; }
    }
}
