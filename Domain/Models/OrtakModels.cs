namespace Domain.Models
{
    public class Secim
    {
        public string Id { get; set; }

        public string Adi { get; set; }
    }

    public class HataGosterTemel
    {
        public bool IsHataMevcut { get; set; }
    }

    public class ParametreEntityTemelModel : HataGosterTemel
    {
        public ParametreEntityTemelModel()
        {
            IsAktif = true;
        }

        public string Adi { get; set; }

        public bool IsAktif { get; set; }
    }

    public class ParametreEntityGuncelleModel : ParametreEntityTemelModel
    {
        public int Id { get; set; }
    }


    public class ParametreEntitySilModel : HataGosterTemel
    {
        public int Id { get; set; }
    }

    public class Sonuc<T>
    {
        public Sonuc(string mesaj)
        {
            HataMesaji = mesaj;
            IsHataVar = true;
        }

        public Sonuc(T sonucDegeri)
        {
            IsHataVar = false;
            Deger = sonucDegeri;
        }
        public Sonuc(long id)
        {
            Identity = id.ToString();
            IsHataVar = false;
        }
        public Sonuc(T sonucDegeri, string mesaj)
        {
            Deger = sonucDegeri;
            HataMesaji = mesaj;
            IsHataVar = true;
        }

        public bool IsHataVar { get; set; }
        public string HataMesaji { get; set; }
        public string Identity { get; set; }
        public T Deger { get; set; }
    }

    public class ComboModel
    {
        public ComboModel()
        {
            //  Aksiyonlar = new List<Secim>();
            // Kontrolculer = new List<Secim>();
            // Menuler = new List<Secim>();           
        }

        //public List<Secim> Aksiyonlar { get; set; }

        //public List<Secim> Kontrolculer { get; set; }

        //public List<Secim> Menuler { get; set; }      
    }

}