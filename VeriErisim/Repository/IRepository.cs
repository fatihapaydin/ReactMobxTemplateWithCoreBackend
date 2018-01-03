using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Models;
using Domain.Varliklar;
using static Domain.GlobalDegiskenler;

namespace VeriErisim.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IAtomik, new()
    {
        TDomain IdsiIleGetir<TDomain>(int id) where TDomain : class, new();

        TDomain FirstOrDefault<TDomain>(Expression<Func<TEntity, bool>> predicate) where TDomain : class, new();

        List<Secim> TekKomboListesiHazirla();

        List<TDomain> ListeGetirSiraliTake<TDomain, TSiralanacakAlan>(
          Expression<Func<TEntity, bool>> containsProperty, Expression<Func<TDomain, TSiralanacakAlan>> orderProperty,
          bool isArtanSiralama, int pageSize) where TDomain : class, new();

        List<TDomain> ListeGetirSirali<TDomain, TSiralanacakAlan>(Expression<Func<TEntity, bool>> containsProperty,
            Expression<Func<TDomain, TSiralanacakAlan>> orderProperty, bool isArtanSiralama) where TDomain : class, new();

        Sonuc<TDomain> Ekle<TDomain>(TDomain tDomain) where TDomain : ParametreEntityTemelModel, new();

        Sonuc<TDomain> Guncelle<TDomain>(TDomain tDomain) where TDomain : ParametreEntityGuncelleModel, new();

        Sonuc<TDomain> Sil<TDomain>(int id) where TDomain : ParametreEntitySilModel, new();

        ComboModel CombolariDoldur(List<EnumCombolar> comboNumaralar);

        bool Any(Expression<Func<TEntity, bool>> predicate);

    }
}
