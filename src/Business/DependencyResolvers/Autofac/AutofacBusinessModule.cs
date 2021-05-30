using Autofac;
using Business.Abstract;
using Business.Concrete;
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
        }
    }
}