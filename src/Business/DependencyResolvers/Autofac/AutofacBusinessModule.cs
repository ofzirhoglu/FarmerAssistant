using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FieldManager>().As<IFieldService>().SingleInstance();
            builder.RegisterType<EfFieldDal>().As<IFieldDal>().SingleInstance();

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