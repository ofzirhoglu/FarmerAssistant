using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISaleTypeService
    {
        IDataResult<List<SaleType>> GetAll();
        IDataResult<SaleType> GetById(int saleTypeId);
        IResult Add(SaleType saleType);
        IResult Update(SaleType saleType);
        IResult Delete(SaleType saleType);
    }
}