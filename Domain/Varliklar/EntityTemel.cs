namespace Domain.Varliklar
{
    public interface IAtomik
    {
        int Id { get; set; }

        bool IsSilinmis { get; set; }

        bool IsAktif { get; set; }
    }

    public interface ITemel : IAtomik
    {
        string Adi { get; set; }
    }

    public static class IAtomikGenisleme
    {
        public static void SilmeyiHazirla(this IAtomik atomik)
        {
            atomik.IsAktif = false;
            atomik.IsSilinmis = true;
        }

        public static void YeniKayitHazirla(this IAtomik atomik)
        {
            atomik.IsAktif = true;
            atomik.IsSilinmis = false;
        }
    }
}