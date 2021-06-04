using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {

        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IResult ChangePassword(ChangePasswordDto changePasswordDto);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int userId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}