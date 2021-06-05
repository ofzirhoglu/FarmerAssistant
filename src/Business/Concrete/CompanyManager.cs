using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult(Messages.CompanyAdded);
        }

        public IResult Delete(Company company)
        {
            var result = _companyDal.GetById(company.CompanyId);

            return result != null
                ? new SuccessResult(Messages.CompanyDeleted)
                : new ErrorResult(Messages.CompanyNotFound);

        }

        public IDataResult<List<Company>> GetAll()
        {
            var result = _companyDal.GetAll();

            return result.Count > 0
                ? new SuccessDataResult<List<Company>>(result, Messages.CompaniesListed)
                : new ErrorDataResult<List<Company>>(result, Messages.CompaniesListNotFound);
        }

        public IDataResult<Company> GetById(int companyId)
        {
            var result = _companyDal.GetById(companyId);

            return result != null
                ? new SuccessDataResult<Company>(result, Messages.CompanyGetById)
                : new ErrorDataResult<Company>(result, Messages.CompanyNotFound);
        }

        public IResult Update(Company company)
        {
            var result = _companyDal.GetById(company.CompanyId);

            return result != null
                ? new SuccessResult(Messages.CompanyUpdated)
                : new ErrorResult(Messages.CompanyNotFound);
        }
    }
}