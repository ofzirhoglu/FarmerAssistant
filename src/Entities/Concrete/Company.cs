using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Company : IEntity
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDesc { get; set; }
    }
}