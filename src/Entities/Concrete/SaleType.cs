using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class SaleType : IEntity
    {
        public int SaleTypeId { get; set; }
        public string SaleTypeName { get; set; }
        public string SaleTypeDesc { get; set; }
    }
}