using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanXe.Models
{
    public class DoiXeDongXe
    {
        public int DoiXeDongXeId { get; set; }

        public int DongXeId { get; set; }
        public DongXe DongXe { get; set; }

        public int DoiXeId { get; set; }
        public DoiXe DoiXe { get; set; }
    }
}
