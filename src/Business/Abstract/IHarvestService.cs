using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IHarvestService
    {
        IDataResult<List<Harvest>> GetAll();

        IDataResult<List<Harvest>> GetAllByHarvestTypeId(int harvestTypeId);

        IDataResult<Harvest> GetById(int harvestId);

        IResult Add(Harvest harvest);

        IResult Update(Harvest harvest);

        IResult Delete(Harvest harvest);
    }
}