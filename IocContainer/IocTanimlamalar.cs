using Autofac;
using Autofac.Extensions.DependencyInjection;
using IsKatmani;
using IsKatmani.IsKatmaniRepository;
using IsKatmani.Arayuzler;
using Microsoft.Extensions.DependencyInjection;
using VeriErisim;
using VeriErisim.Repository;
using VeriErisim.Arayuzler;
using IsKatmani.Concrete;
using VeriErisim.Concrete;

namespace IocContainer
{
    public class AutoFacTanimlamalar
    {
        public static IContainer Tanimla(IServiceCollection serviceCollection)
        {
            var builder = new ContainerBuilder();


            #region Business Tanımlamaları 

            builder.RegisterGeneric(typeof(TemelServis<>)).As(typeof(ITemelServis<>))
                .InstancePerDependency();

            builder.RegisterType<BolumServis>().As<IBolumServis>();

            #endregion




            #region Veri Erişim Tanımlamamları

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>))
                .InstancePerDependency();

            builder.RegisterType<EfBolumOperasyon>().As<IBolumOperasyon>();

            #endregion


            //serviceCollection.AddDbContextPool<OkulContext>(options => options.UseSqlServer("Server=DESKTOP-8BGLM9G\\SQLFATIH;Database=OkulCore2App;Trusted_Connection=True;MultipleActiveResultSets = true"));

            builder.Populate(serviceCollection);

            return builder.Build();
        }
    }
}