using AutoMapper;
using Domain.Varliklar;
using Domain.Models;

namespace VeriErisim.Context
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                //.ForMember(hedef => hedef, kaynak => kaynak.MapFrom(y => y))
                //.ForMember(hedef => hedef, kaynak => kaynak.MapFrom(y => y))
                //.ForMember(hedef => hedef, kaynak => kaynak.MapFrom(y => y))


                #region Bölüm Mappings 

                x.CreateMap<Bolum, BolumListeModel>();


                //x.CreateMap<Bolum, BolumDetayDomainModel>();

                x.CreateMap<YeniBolumModel, Bolum>();

                x.CreateMap<BolumGuncelleModel, Bolum>().ReverseMap();
                //x.CreateMap<Bolum, BolumSilModel>().ReverseMap();

                x.CreateMap<Bolum, Secim>()
                .ForMember(hedef => hedef.Id, kaynak => kaynak.MapFrom(y => y.Id));

                #endregion

            });
        }
    }
}
