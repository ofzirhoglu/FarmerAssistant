using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<FieldManager>().As<IFieldService>().SingleInstance();
            builder.RegisterType<EfFieldDal>().As<IFieldDal>().SingleInstance();

            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

            builder.RegisterType<SaleTypeManager>().As<ISaleTypeService>().SingleInstance();
            builder.RegisterType<EfSaleTypeDal>().As<ISaleTypeDal>().SingleInstance();

            builder.RegisterType<SaleManager>().As<ISaleService>().SingleInstance();
            builder.RegisterType<EfSaleDal>().As<ISaleDal>().SingleInstance();

            builder.RegisterType<HarvestTypeManager>().As<IHarvestTypeService>().SingleInstance();
            builder.RegisterType<EfHarvestTypeDal>().As<IHarvestTypeDal>().SingleInstance();

            // Çalışan uygulama içerisinde ...
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            // ... Implemente edilmiş interface leri bul ...
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    // ... ve onlar için AspectInterceptorSelector ı çağır
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}