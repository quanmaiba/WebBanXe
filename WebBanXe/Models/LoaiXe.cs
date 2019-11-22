using System.Collections.Generic;

namespace WebBanXe.Models
{
    public class LoaiXe
    {
        public int LoaiXeId { get; set; }
        public string TenLoaiXe { get; set; }


        public IEnumerable<TheLoaiXe> TheLoaiXes { get; set; }
    }
}
