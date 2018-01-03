using Domain.Varliklar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VeriErisim.Repository;
using Domain;
using Domain.Models;

namespace IsKatmani.IsKatmaniRepository
{
    public class TemelServis<TEntity> : ITemelServis<TEntity> where TEntity : class, IAtomik, new()
    {
        private readonly IRepository<TEntity> _repo;

        public TemelServis(IRepository<TEntity> repo)
        {
            _repo = repo;
        }

        public ComboModel CombolariDoldur(List<GlobalDegiskenler.EnumCombolar> combolar)
        {
            return _repo.CombolariDoldur(combolar);
        }

        public Sonuc<TDomain> Ekle<TDomain>(TDomain tDomain, Expression<Func<TEntity, bool>> anySorgu, string hataMesaji) where TDomain : ParametreEntityTemelModel, new()
        {
            if (!_repo.Any(anySorgu))
                return _repo.Ekle(tDomain);

            tDomain.IsHataMevcut = true;
            return new Sonuc<TDomain>(tDomain, hataMesaji);
        }

        public TDomain FirstOrDefault<TDomain>(Expression<Func<TEntity, bool>> predicate) where TDomain : class, new()
        {
            return _repo.FirstOrDefault<TDomain>(predicate);
        }

        public Sonuc<TDomain> Guncelle<TDomain>(TDomain tDomain, Expression<Func<TEntity, bool>> anySorgu, string hataMesaji) where TDomain : ParametreEntityGuncelleModel, new()
        {
            if (!_repo.Any(anySorgu))
                return _repo.Guncelle(tDomain);

            tDomain.IsHataMevcut = true;
            return new Sonuc<TDomain>(tDomain, hataMesaji);
        }

        public TDomain IdsiIleGetir<TDomain>(int id) where TDomain : class, new()
        {
            return _repo.IdsiIleGetir<TDomain>(id);
        }

        public List<TDomain> ListeGetirSirali<TDomain, TSiralanacakAlan>(Expression<Func<TEntity, bool>> containsProperty, Expression<Func<TDomain, TSiralanacakAlan>> orderProperty, bool isArtanSiralama = true) where TDomain : class, new()
        {
            return _repo.ListeGetirSirali(containsProperty, orderProperty, isArtanSiralama);
        }

        public Sonuc<TDomain> Sil<TDomain>(TDomain tDomain, Expression<Func<TEntity, bool>> anySorgu, string hataMesaji) where TDomain : ParametreEntitySilModel, new()
        {
            if (!_repo.Any(anySorgu))
                return _repo.Sil<TDomain>(tDomain.Id);

            tDomain.IsHataMevcut = true;
            return new Sonuc<TDomain>(tDomain, hataMesaji);
        }

        public Sonuc<TDomain> Sil<TDomain>(TDomain tDomain, Dictionary<Expression<Func<TEntity, bool>>, string> anySorgular) where TDomain : ParametreEntitySilModel, new()
        {
            foreach (var item in anySorgular)
            {
                if (_repo.Any(item.Key))
                {
                    tDomain.IsHataMevcut = true;
                    return new Sonuc<TDomain>(tDomain, item.Value);
                }
            }
            return _repo.Sil<TDomain>(tDomain.Id);
        }

        public List<Secim> TekKomboListesiHazirla()
        {
            return _repo.TekKomboListesiHazirla();
        }


    }
}