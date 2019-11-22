using System.Collections.Generic;

namespace WebBanXe.Models
{
    public class KmDaDi
    {
        public int KmDaDiId { get; set; }
        public string TenKmDaDi { get; set; }

        public IEnumerable<SanPham> SanPhams { get; set; }
    }
}
