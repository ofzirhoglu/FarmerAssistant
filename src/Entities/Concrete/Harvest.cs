using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Harvest : IEntity
    {
        public int HarvestId { get; set; }
        public int HarvestTypeId { get; set; }
        public int FieldId { get; set; }
        public double HarvestQuantity { get; set; }
        public DateTime HarvestDate { get; set; }
        public string HarvestDesc { get; set; }
    }
}