using System.Collections.Generic;

namespace WebBanXe.Models
{
    public class DoiXe
    {
        public int DoiXeId { get; set; }
        public string TenDoiXe { get; set; }

        public IEnumerable<DoiXeDongXe> DoiXes { get; set; }
    }
}
