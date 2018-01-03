namespace Domain.Models
{
    public class BolumListeModel
    {
        public int Id { get; set; }

        public string Adi { get; set; }

        public decimal Butce { get; set; }

        public string Kod { get; set; }
    }

    public class YeniBolumModel : ParametreEntityTemelModel
    {
        public decimal Butce { get; set; }

        public string Kod { get; set; }
    }

    public class BolumGuncelleModel : ParametreEntityGuncelleModel
    {
        public decimal Butce { get; set; }

        public string Kod { get; set; }
    }
}