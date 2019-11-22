using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebBanXe.Models
{
    public class HangXe
    {
        public int HangXeId { get; set; }
        public string TenHangXe { get; set; }

        public string IMG { get; set; }
        public IEnumerable<DongXe> DongXes { get; set; }
    }
}
