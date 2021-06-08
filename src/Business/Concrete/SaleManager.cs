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
    public class SaleManager : ISaleService
    {

        private readonly ISaleDal _saleDal;

        public SaleManager(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }

        [ValidationAspect(typeof(SaleValidator))]
        public IResult Add(Sale sale)
        {
            _saleDal.Add(sale);
            return new SuccessResult(Messages.SaleAdded);
        }

        public IResult Delete(Sale sale)
        {
            var result = _saleDal.GetById(sale.SaleId);

            if (result == null)
            {
                return new ErrorResult(Messages.SaleNotFound);
            }
            _saleDal.Delete(sale);
            return new SuccessResult(Messages.SaleDeleted);
        }

        public IDataResult<List<Sale>> GetAll()
        {
            var result = _saleDal.GetAll();
            return result.Count > 0
                ? new SuccessDataResult<List<Sale>>(result, Messages.SalesListed)
                : new ErrorDataResult<List<Sale>>(result, Messages.SalesListNotFound);
        }

        public IDataResult<List<Sale>> GetAllBySaleTypeId(int saleTypeId)
        {
            var result = _saleDal.GetAll(x => x.SaleTypeId == saleTypeId);
            return result.Count > 0
                ? new SuccessDataResult<List<Sale>>(result, Messages.SalesListedBySalesTypeId)
                : new ErrorDataResult<List<Sale>>(result, Messages.SalesListBySalesTypeIdNotFound);
        }

        public IDataResult<Sale> GetById(int saleId)
        {
            var result = _saleDal.GetById(saleId);
            return result != null
                ? new SuccessDataResult<Sale>(result, Messages.SaleGetById)
                : new ErrorDataResult<Sale>(result, Messages.SaleNotFound);
        }

        public IResult Update(Sale sale)
        {
            var result = _saleDal.GetById(sale.SaleId);

            if (result == null)
            {
                return new ErrorResult(Messages.SaleNotFound);
            }
            _saleDal.Update(sale);
            return new SuccessResult(Messages.SaleUpdated);
        }
    }
}