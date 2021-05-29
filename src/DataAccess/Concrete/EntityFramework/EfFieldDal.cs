using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFieldDal : EfEntityRepositoryBase<Field, FarmerAssistantDbContext>, IFieldDal
    {

    }
}