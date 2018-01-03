using Domain.Varliklar;
using IsKatmani.Arayuzler;
using IsKatmani.IsKatmaniRepository;
using VeriErisim.Arayuzler;
using VeriErisim.Repository;

namespace IsKatmani.Concrete
{
    public class BolumServis : TemelServis<Bolum>, IBolumServis
    {
        private readonly IBolumOperasyon _bolumOperasyon;

        public BolumServis(IBolumOperasyon bolumOperasyon) : base(bolumOperasyon)
        {
            _bolumOperasyon = bolumOperasyon;
        }
    }
}