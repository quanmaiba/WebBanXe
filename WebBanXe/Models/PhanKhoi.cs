using System.Collections.Generic;

namespace WebBanXe.Models
{
    public class PhanKhoi
    {
        public int PhanKhoiId { get; set; }
        public string TenPhanKhoi { get; set; }

        public IEnumerable<DongXe> DongXes { get; set; }
    }
}
