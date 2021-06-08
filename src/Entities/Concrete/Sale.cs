using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Sale : IEntity
    {
        public int SaleId { get; set; }
        public int FieldId { get; set; }
        public int CompanyId { get; set; }
        public int SaleTypeId { get; set; }
        public DateTime SaleDate { get; set; }
        public double SaleQuantity { get; set; }
        public decimal SaleUnitPrice { get; set; }
        public decimal SaleTotalPrice { get; set; }
        public string SaleDesc { get; set; }

    }
}