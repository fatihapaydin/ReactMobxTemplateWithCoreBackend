namespace Domain.Varliklar
{
    public class Bolum : ITemel
    {
        public int Id { get; set; }

        public bool IsAktif { get; set; }

        public bool IsSilinmis { get; set; }

        public string Adi { get; set; }

        public string Kod { get; set; }

        public decimal Butce { get; set; }

    }
}