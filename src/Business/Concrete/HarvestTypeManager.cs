using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidatiionRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class HarvestTypeManager : IHarvestTypeService
    {

        private readonly IHarvestTypeDal _harvestTypeDal;

        public HarvestTypeManager(IHarvestTypeDal harvestTypeDal)
        {
            _harvestTypeDal = harvestTypeDal;
        }

        [ValidationAspect(typeof(HarvestTypeValidator))]
        public IResult Add(HarvestType harvestType)
        {
            var result = BusinessRules.Run(CheckIfHarvestTypeNameExistsForAdd(harvestType.HarvestTypeName));

            if (result != null)
            {
                return result;
            }
            _harvestTypeDal.Add(harvestType);
            return new SuccessResult(Messages.HarvestTypeAdded);
        }

        public IResult Delete(HarvestType harvestType)
        {
            var result = _harvestTypeDal.GetById(harvestType.HarvestTypeId);

            if (result == null)
            {
                return new ErrorResult(Messages.HarvestTypeNotFound);
            }
            _harvestTypeDal.Delete(harvestType);
            return new SuccessResult(Messages.HarvestTypeDeleted);
        }

        public IDataResult<List<HarvestType>> GetAll()
        {
            var result = _harvestTypeDal.GetAll();
            return result.Count > 0
                ? new SuccessDataResult<List<HarvestType>>(result, Messages.HarvestTypesListed)
                : new ErrorDataResult<List<HarvestType>>(result, Messages.HarvestTypesListNotFound);
        }

        public IDataResult<HarvestType> GetById(int harvestTypeId)
        {
            var result = _harvestTypeDal.GetById(harvestTypeId);
            return result != null
                ? new SuccessDataResult<HarvestType>(result, Messages.HarvestTypeGetById)
                : new ErrorDataResult<HarvestType>(result, Messages.HarvestTypeNotFound);
        }

        public IResult Update(HarvestType harvestType)
        {
            var result = BusinessRules.Run(CheckIfHarvestTypeNameExistsForUpdate(harvestType.HarvestTypeName, harvestType.HarvestTypeId));

            if (result != null)
            {
                return result;
            }
            _harvestTypeDal.Update(harvestType);
            return new SuccessResult(Messages.HarvestTypeUpdated);
        }

        //! Business Rules

        private IResult CheckIfHarvestTypeNameExistsForAdd(string harvestTypeName)
        {
            var result = _harvestTypeDal.GetAll(f => f.HarvestTypeName == harvestTypeName).Any();

            return result
                ? new ErrorResult(Messages.HarvestTypeNameAlreadyExists)
                : new SuccessResult();
        }

        private IResult CheckIfHarvestTypeNameExistsForUpdate(string harvestTypeName, int harvestTypeId)
        {
            var result = _harvestTypeDal.GetAll(f => f.HarvestTypeName == harvestTypeName && f.HarvestTypeId != harvestTypeId).Any();

            return result
                ? new ErrorResult(Messages.HarvestTypeNameAlreadyExists)
                : new SuccessResult();
        }
    }
}