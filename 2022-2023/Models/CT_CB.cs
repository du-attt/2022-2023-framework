namespace _2022_2023.Models
{
    public class CT_CB
    {
        private string macb, mahk, soghe;
        private int loaighe;
        public CT_CB() { }
        public CT_CB(string macb, string mahk, string soghe, int loaighe)
        {
            this.macb = macb;
            this.mahk = mahk;
            this.soghe = soghe;
            this.loaighe = loaighe;
        }
        public string Macb { get => macb; set => macb = value; }
        public string Mahk { get => mahk; set => mahk = value; }
        public string SoGhe { get => soghe; set => soghe = value; }
        public int LoaiGhe { get => loaighe; set => loaighe = value; }

    }
}
