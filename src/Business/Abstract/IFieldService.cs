using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFieldService
    {
        IDataResult<List<Field>> GetAll();
        IDataResult<Field> GetById(int fieldId);
        IResult Add(Field field);
        IResult Update(Field field);

        IResult Delete(Field field);

    }
}