namespace WebBanXe.Models
{
    public class TheLoaiXe
    {
        public int TheLoaiXeId { get; set; }
        public string TenTheLoaiXe { get; set; }

        public int LoaiXeId { get; set; }
        public LoaiXe LoaiXe { get; set; }
    }
}
