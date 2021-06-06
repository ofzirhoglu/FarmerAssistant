using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IHarvestTypeService
    {
        IDataResult<List<HarvestType>> GetAll();
        IDataResult<HarvestType> GetById(int harvestTypeId);
        IResult Add(HarvestType harvestType);
        IResult Update(HarvestType harvestType);
        IResult Delete(HarvestType harvestType);
    }
}