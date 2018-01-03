using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Models;
using Domain.Varliklar;
using static Domain.GlobalDegiskenler;

namespace IsKatmani.IsKatmaniRepository
{
    public interface ITemelServis<TEntity> where TEntity : IAtomik
    {
        TDomain IdsiIleGetir<TDomain>(int id) where TDomain : class, new();

        TDomain FirstOrDefault<TDomain>(Expression<Func<TEntity, bool>> predicate) where TDomain : class, new();

        List<Secim> TekKomboListesiHazirla();


        List<TDomain> ListeGetirSirali<TDomain, TSiralanacakAlan>(Expression<Func<TEntity, bool>> containsProperty, Expression<Func<TDomain, TSiralanacakAlan>> orderProperty,
          bool isArtanSiralama) where TDomain : class, new();

        Sonuc<TDomain> Ekle<TDomain>(TDomain tDomain, Expression<Func<TEntity, bool>> anySorgu, string hataMesaji) where TDomain : ParametreEntityTemelModel, new();

        Sonuc<TDomain> Guncelle<TDomain>(TDomain tDomain, Expression<Func<TEntity, bool>> anySorgu, string hataMesaji) where TDomain : ParametreEntityGuncelleModel, new();

        Sonuc<TDomain> Sil<TDomain>(TDomain tDomain, Expression<Func<TEntity, bool>> anySorgu, string hataMesaji = "") where TDomain : ParametreEntitySilModel, new();

        Sonuc<TDomain> Sil<TDomain>(TDomain tDomain, Dictionary<Expression<Func<TEntity, bool>>, string> anySorgular) where TDomain : ParametreEntitySilModel, new();

        ComboModel CombolariDoldur(List<EnumCombolar> combolar);

    }
}