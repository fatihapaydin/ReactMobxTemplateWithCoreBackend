using System;
using System.Collections.Generic;
using VeriErisim.Context;
using System.Linq;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Domain.Varliklar;
using Domain.Models;
using AutoMapper;
using static Domain.GlobalDegiskenler;
using Domain;

namespace VeriErisim.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAtomik, new()
    {
        public TDomain IdsiIleGetir<TDomain>(int id) where TDomain : class, new()
        {
            using (var db = new OkulContext())
            {
                return IdsiIleGetir<TDomain>(id, db);
            }
        }

        protected TDomain IdsiIleGetir<TDomain>(int id, OkulContext db)
        {
            return db.Set<TEntity>().Where(x => x.Id == id && x.IsAktif && !x.IsSilinmis).ProjectTo<TDomain>().FirstOrDefault();
        }

        public TDomain FirstOrDefault<TDomain>(Expression<Func<TEntity, bool>> predicate) where TDomain : class, new()
        {
            using (var db = new OkulContext())
            {
                return db.Set<TEntity>().Where(x => !x.IsSilinmis).Where(predicate).ProjectTo<TDomain>().FirstOrDefault();
            }
        }

        public List<Secim> TekKomboListesiHazirla()
        {
            using (var db = new OkulContext())
            {
                return db.Set<TEntity>().Where(x => x.IsAktif && !x.IsSilinmis)
                    .ProjectTo<Secim>()
                    .OrderBy(x => x.Adi)
                    .ToList();
            }
        }


        public List<TDomain> ListeGetirSiraliTake<TDomain, TSiralanacakAlan>(
         Expression<Func<TEntity, bool>> containsProperty, Expression<Func<TDomain, TSiralanacakAlan>> orderProperty,
         bool isArtanSiralama, int pageSize) where TDomain : class, new()
        {
            using (var db = new OkulContext())
            {
                var siralamaYapilanSutun = orderProperty.Body.ToString().Split('.')[1];

                return db.Set<TEntity>().Where(x => x.IsAktif && !x.IsSilinmis).Where(containsProperty)
                        .ProjectTo<TDomain>()
                        .ListeyiSirala(isArtanSiralama, siralamaYapilanSutun)
                        .Take(pageSize)
                        .ToList();
            }
        }

        public List<TDomain> ListeGetirSirali<TDomain, TSiralanacakAlan>(
          Expression<Func<TEntity, bool>> containsProperty, Expression<Func<TDomain, TSiralanacakAlan>> orderProperty, bool isArtanSiralama = true) where TDomain : class, new()
        {
            using (var db = new OkulContext())
            {
                var siralamaYapilanSutun = orderProperty.Body.ToString().Split('.')[1];

                var liste = db.Set<TEntity>().Where(x => x.IsAktif && !x.IsSilinmis).Where(containsProperty).ProjectTo<TDomain>().ListeyiSirala(isArtanSiralama, siralamaYapilanSutun)
                        .ToList();

                return liste;
            }
        }

        public Sonuc<TDomain> Ekle<TDomain>(TDomain domain) where TDomain : ParametreEntityTemelModel, new()
        {
            using (var db = new OkulContext())
            {
                var entity = AutoMapper.Mapper.Map<TEntity>(domain);
                entity.YeniKayitHazirla();
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
                return new Sonuc<TDomain>(entity.Id);
            }
        }

        protected TEntity GuncellemeyiHazirla<TDomain>(TDomain domain, OkulContext db)
        {
            var guncelKayit = Mapper.Map<TEntity>(domain);

            var veriTabanindakiKayit = db.Set<TEntity>().Find(guncelKayit.Id);

            db.Entry(veriTabanindakiKayit).CurrentValues.SetValues(guncelKayit);

            return guncelKayit;
        }

        public Sonuc<TDomain> Guncelle<TDomain>(TDomain tDomain) where TDomain : ParametreEntityGuncelleModel, new()
        {
            using (var db = new OkulContext())
            {
                var guncelKayit = GuncellemeyiHazirla(tDomain, db);
                db.SaveChanges();
                return new Sonuc<TDomain>(tDomain.Id);
            }
        }

        public Sonuc<TDomain> Sil<TDomain>(int id) where TDomain : ParametreEntitySilModel, new()
        {
            using (var db = new OkulContext())
            {
                var silinecekKayit = db.Set<TEntity>().Find(id);
                silinecekKayit.SilmeyiHazirla();
                db.Entry(silinecekKayit).State = EntityState.Modified;
                db.SaveChanges();
                return new Sonuc<TDomain>(id);
            }
        }

        public ComboModel CombolariDoldur(List<EnumCombolar> combolar)
        {
            using (var db = new OkulContext())
            {
                var comboModel = new ComboModel();

                foreach (var index in combolar)
                {
                    /*  switch (index)
                      {
                           case EnumCombolar.Aksiyonlar:
                               comboModel.Aksiyonlar = db.KomboDoldur<Aksiyon>();
                               break;

                           case EnumCombolar.Kontrolculer:
                               comboModel.Kontrolculer = db.KomboDoldur<Kontrolcu>();
                               break;

                           case EnumCombolar.Menuler:
                               comboModel.Menuler = db.KomboDoldur<Menu>();
                               break;

                  }*/
                }

                return comboModel;
            }
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = new OkulContext())
            {
                return db.Set<TEntity>().Any(predicate);
            }
        }


    }
}