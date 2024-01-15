namespace _2022_2023.Models
{
    public class ChuyenBay
    {
        private string mach, tench, ddi, dden, ngay, gbay, gden, mamb;
        private int thuong, vip;
        public ChuyenBay() { }
        public ChuyenBay(string mach, string tench, string ddi, string dden, string ngay, string gbay, string gden, string mamb, int thuong, int vip)
        {
            this.mach = mach;
            this.tench = tench;
            this.ddi = ddi;
            this.dden = dden;
            this.ngay = ngay;
            this.gbay = gbay;
            this.gden = gden;
            this.mamb = mamb;
            this.thuong = thuong;
            this.vip = vip;
        }
        public string MaCH { get => mach; set => mach = value; }
        public string TenCH { get => tench; set => tench = value; }
        public string DDi { get => ddi; set => ddi = value; }
        public string DDen { get => dden; set => dden = value; }
        public string Ngay { get => ngay; set => ngay = value; }
        public string GBay { get => gbay; set => gbay = value; }
        public string GDen { get => gden; set => gden = value; }
        public string MaMB { get => mamb; set => mamb = value; }
        public int Thuong { get => thuong; set => thuong = value; }
        public int VIP { get => vip; set => vip = value; }

    }
}
