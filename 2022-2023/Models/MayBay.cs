namespace _2022_2023.Models
{
    public class MayBay
    {
        private string mamb, hangmb;
        private int socho;

        public MayBay() { }
        public MayBay(string mamb, string hangmb, int socho)
        {
            this.mamb = mamb;
            this.hangmb = hangmb;
            this.socho = socho;
        }

        public string Mamb { get => mamb; set => mamb = value; }
        public string Hangmb { get => hangmb; set => hangmb = value; }
        public int Socho { get => socho; set => socho = value; }

    }
}
