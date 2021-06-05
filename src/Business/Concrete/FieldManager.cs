using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidatiionRules.FluentValidation;
using BusinessAspects.Autofac;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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

        [SecuredOperation("field.add,admin")]
        [ValidationAspect(typeof(FieldValidator))]
        public IResult Add(Field field)
        {
            var result = BusinessRules.Run(CheckIfFieldNameExists(field.FieldName));

            if (result != null)
            {
                return result;
            }

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
            return new SuccessDataResult<Field>(_fieldDal.GetById(fieldId), Messages.FieldGetById);
        }

        public IResult Update(Field field)
        {
            var result = BusinessRules.Run(CheckIfFieldNameExists(field.FieldName));

            if (result != null)
            {
                return result;
            }
            _fieldDal.Update(field);
            return new SuccessResult(Messages.FieldUpdated);
        }

        //! Business Rules

        private IResult CheckIfFieldNameExists(string fieldName)
        {
            var result = _fieldDal.GetAll(f => f.FieldName == fieldName).Any();

            return result
            ? new ErrorResult(Messages.FieldNameAlreadyExists)
            : new SuccessResult();
        }
    }
}