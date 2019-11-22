using System.Collections.Generic;

namespace WebBanXe.Models
{
    public class XuatXu
    {
        public int XuatXuId { get; set; }
        public string TenXuatXu { get; set; }

        public IEnumerable<SanPham> SanPhams { get; set; }
    }
}
