using System.Collections.Generic;

namespace WebBanXe.Models
{
    public class DiaDiemHuyen
    {
        public int DiaDiemHuyenId { get; set; }
        public string TenDiaDiemHuyen { get; set; }

        public int DiaDiemTinhId { get; set; }
        public DiaDiemTinh DiaDiemTinh { get; set; }

        public IEnumerable<SanPham> SanPhams { get; set; }
    }
}
