using System.Collections.Generic;

namespace WebBanXe.Models
{
    public class DiaDiemTinh
    {
        public int DiaDiemTinhId { get; set; }
        public string TenDiaDiemTinh { get; set; }

        public IEnumerable<DiaDiemHuyen> DiaDiemHuyens { get; set; }
    }
}
