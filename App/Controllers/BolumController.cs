using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using IsKatmani.Arayuzler;

namespace App.Controllers
{
    [Route("api/[controller]")]
    public class BolumController : Controller
    {
        private readonly IBolumServis _bolumServis;

        public BolumController(IBolumServis bolumServis)
        {
            _bolumServis = bolumServis;
        }

        [HttpGet("[action]")]
        public List<BolumListeModel> Liste()
        {
            return _bolumServis.ListeGetirSirali<BolumListeModel, string>(x => true, x => x.Adi, true);
        }

        [HttpPost("[action]")]
        public void Ekle(YeniBolumModel yeniBolumModel)
        {
            _bolumServis.Ekle(yeniBolumModel, x => x.Adi == yeniBolumModel.Adi, yeniBolumModel.Adi + " adında bir bölüm mevcut");
        }

        [HttpGet("[action]")]
        public Mesaj MesajAl(string deger)
        {
            return new Mesaj { Metin = deger == null ? "Mesaj alınamadı" : deger + " alındı" };
        }

        [HttpPost("[action]")]
        public void Guncelle(BolumGuncelleModel bolumGuncelleModel)
        {
            _bolumServis.Guncelle(bolumGuncelleModel, x => x.Adi == bolumGuncelleModel.Adi && x.Id != bolumGuncelleModel.Id, bolumGuncelleModel.Adi + " adında bir bölüm var");
        }

        /* 
                [HttpPost("[action]")]
                public void Sil(int id)
                {
                    _bolumServis.Sil(id,);
                }
        */

    }

    public class Mesaj
    {
        public string Metin { get; set; }
    }

}