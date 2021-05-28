using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class HarvestType : IEntity
    {
        public int HarvestTypeId { get; set; }
        public string HarvestTypeName { get; set; }
        public string HarvestTypeDesc { get; set; }

    }
}