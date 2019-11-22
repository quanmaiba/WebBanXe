using System.Collections.Generic;

namespace WebBanXe.Models
{
    public class MauXe
    {
        public int MauXeId { get; set; }
        public string TenMauXe { get; set; }

        public IEnumerable<SanPham> SanPhams { get; set; }
    }
}
