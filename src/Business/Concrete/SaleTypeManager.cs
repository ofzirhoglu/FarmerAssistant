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
    public class SaleTypeManager : ISaleTypeService
    {

        private readonly ISaleTypeDal _saleTypeDal;

        public SaleTypeManager(ISaleTypeDal saleTypeDal)
        {
            _saleTypeDal = saleTypeDal;
        }

        [ValidationAspect(typeof(SaleTypeValidator))]
        public IResult Add(SaleType saleType)
        {
            var result = BusinessRules.Run(CheckIfSaleTypeNameExistsForAdd(saleType.SaleTypeName));

            if (result != null)
            {
                return result;
            }
            _saleTypeDal.Add(saleType);
            return new SuccessResult(Messages.SaleTypeAdded);
        }

        public IResult Delete(SaleType saleType)
        {
            var result = _saleTypeDal.GetById(saleType.SaleTypeId);

            if (result == null)
            {
                return new ErrorResult(Messages.SaleTypeNotFound);
            }
            _saleTypeDal.Delete(saleType);
            return new SuccessResult(Messages.SaleTypeDeleted);
        }

        public IDataResult<List<SaleType>> GetAll()
        {
            var result = _saleTypeDal.GetAll();
            return result.Count > 0
                ? new SuccessDataResult<List<SaleType>>(result, Messages.SaleTypesListed)
                : new ErrorDataResult<List<SaleType>>(result, Messages.SaleTypesListNotFound);
        }

        public IDataResult<SaleType> GetById(int saleTypeId)
        {
            var result = _saleTypeDal.GetById(saleTypeId);
            return result != null
                ? new SuccessDataResult<SaleType>(result, Messages.SaleTypeGetById)
                : new ErrorDataResult<SaleType>(result, Messages.SaleTypeNotFound);
        }

        public IResult Update(SaleType saleType)
        {
            var result = BusinessRules.Run(CheckIfSaleTypeNameExistsForUpdate(saleType.SaleTypeName, saleType.SaleTypeId));

            if (result != null)
            {
                return result;
            }
            _saleTypeDal.Update(saleType);
            return new SuccessResult(Messages.SaleTypeUpdated);
        }

        //! Business Rules

        private IResult CheckIfSaleTypeNameExistsForAdd(string saleTypeName)
        {
            var result = _saleTypeDal.GetAll(f => f.SaleTypeName == saleTypeName).Any();

            return result
            ? new ErrorResult(Messages.SaleTypeNameAlreadyExists)
            : new SuccessResult();
        }

        private IResult CheckIfSaleTypeNameExistsForUpdate(string saleTypeName, int saleTypeId)
        {
            var result = _saleTypeDal.GetAll(f => f.SaleTypeName == saleTypeName && f.SaleTypeId != saleTypeId).Any();

            return result
            ? new ErrorResult(Messages.SaleTypeNameAlreadyExists)
            : new SuccessResult();
        }
    }
}