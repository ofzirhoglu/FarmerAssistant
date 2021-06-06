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

            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();

            builder.RegisterType<SaleTypeManager>().As<ISaleTypeService>();
            builder.RegisterType<EfSaleTypeDal>().As<ISaleTypeDal>();

            builder.RegisterType<HarvestTypeManager>().As<IHarvestTypeService>();
            builder.RegisterType<EfHarvestTypeDal>().As<IHarvestTypeDal>();

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