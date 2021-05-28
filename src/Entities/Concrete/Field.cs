using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Field : IEntity
    {
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public string FieldDesc { get; set; }
        public double FieldM2 { get; set; }
    }
}