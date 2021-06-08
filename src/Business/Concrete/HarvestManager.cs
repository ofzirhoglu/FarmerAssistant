using Business.Abstract;
using Business.Constants;
using Business.ValidatiionRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class HarvestManager : IHarvestService
    {
        private readonly IHarvestDal _harvestDal;

        public HarvestManager(IHarvestDal harvestDal)
        {
            _harvestDal = harvestDal;
        }

        [ValidationAspect(typeof(HarvestValidator))]
        public IResult Add(Harvest harvest)
        {
            _harvestDal.Add(harvest);
            return new SuccessResult(Messages.HarvestAdded);
        }

        public IResult Delete(Harvest harvest)
        {
            var result = _harvestDal.GetById(harvest.HarvestId);

            if (result == null)
            {
                return new ErrorResult(Messages.HarvestNotFound);
            }
            _harvestDal.Delete(harvest);
            return new SuccessResult(Messages.HarvestDeleted);
        }

        public IDataResult<List<Harvest>> GetAll()
        {
            var result = _harvestDal.GetAll();
            return result.Count > 0
                ? new SuccessDataResult<List<Harvest>>(result, Messages.HarvestsListed)
                : new ErrorDataResult<List<Harvest>>(result, Messages.HarvestsListNotFound);
        }

        public IDataResult<List<Harvest>> GetAllByHarvestTypeId(int harvestTypeId)
        {
            var result = _harvestDal.GetAll(x => x.HarvestTypeId == harvestTypeId);
            return result.Count > 0
                ? new SuccessDataResult<List<Harvest>>(result, Messages.HarvestsListedByHarvestsTypeId)
                : new ErrorDataResult<List<Harvest>>(result, Messages.HarvestsListByHarvestsTypeIdNotFound);
        }

        public IDataResult<Harvest> GetById(int harvestId)
        {
            var result = _harvestDal.GetById(harvestId);
            return result != null
                ? new SuccessDataResult<Harvest>(result, Messages.HarvestGetById)
                : new ErrorDataResult<Harvest>(result, Messages.HarvestNotFound);
        }

        public IResult Update(Harvest harvest)
        {
            var result = _harvestDal.GetById(harvest.HarvestId);

            if (result == null)
            {
                return new ErrorResult(Messages.HarvestNotFound);
            }
            _harvestDal.Update(harvest);
            return new SuccessResult(Messages.HarvestUpdated);
        }
    }
}