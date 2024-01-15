namespace _2022_2023.Models
{
    public class HanhKhach
    {
        private string mahk, hoten, diachi, dienthoai;
        public HanhKhach() { }
        public HanhKhach(string mahk, string hoten, string diachi, string dienthoai)
        {
            this.mahk = mahk;
            this.hoten = hoten;
            this.diachi = diachi;
            this.dienthoai = dienthoai;
        }
        public string Mahk { get => mahk; set => mahk = value; }
        public string HoTen { get => hoten; set => hoten = value; }
        public string DiaChi { get => diachi; set => diachi = value; }
        public string DienThoai { get => dienthoai; set => dienthoai = value; }

    }
}
