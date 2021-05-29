using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FieldManager : IFieldService
    {
        IFieldDal _fieldDal;

        public FieldManager(IFieldDal fieldDal)
        {
            _fieldDal = fieldDal;
        }

        public IResult Add(Field field)
        {
            _fieldDal.Add(field);
            return new SuccessResult(Messages.FieldAdded);
        }

        public IResult Delete(Field field)
        {
            _fieldDal.Delete(field);
            return new SuccessResult(Messages.FieldDeleted);
        }

        public IDataResult<List<Field>> GetAll()
        {
            return new SuccessDataResult<List<Field>>(_fieldDal.GetAll(), Messages.FieldsListed);
        }

        public IDataResult<Field> GetById(int fieldId)
        {
            return new SuccessDataResult<Field>(_fieldDal.Get(f => f.FieldId == fieldId), Messages.FieldGetById);
        }

        public IResult Update(Field field)
        {
            _fieldDal.Update(field);
            return new SuccessResult(Messages.FieldUpdated);
        }
    }
}