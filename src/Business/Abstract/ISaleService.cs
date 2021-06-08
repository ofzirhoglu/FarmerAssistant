using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISaleService
    {
        IDataResult<List<Sale>> GetAll();
        IDataResult<List<Sale>> GetAllBySaleTypeId(int saleTypeId);
        IDataResult<Sale> GetById(int saleId);
        IResult Add(Sale sale);
        IResult Update(Sale sale);
        IResult Delete(Sale sale);
    }
}