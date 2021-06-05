using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> GetAll();
        IDataResult<Company> GetById(int companyId);
        IResult Add(Company company);
        IResult Update(Company company);
        IResult Delete(Company company);
    }
}