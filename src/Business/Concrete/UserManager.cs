using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult ChangePassword(ChangePasswordDto changePasswordDto)
        {
            byte[] passwordHash, passwordSalt;
            var userToCheck = GetByMail(changePasswordDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(changePasswordDto.OldPassWord, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorResult(Messages.PasswordError);
            }
            HashingHelper.CreatePasswordHash(changePasswordDto.NewPassword, out passwordHash, out passwordSalt);
            userToCheck.Data.PasswordHash = passwordHash;
            userToCheck.Data.PasswordSalt = passwordSalt;
            _userDal.Update(userToCheck.Data);
            return new SuccessResult(Messages.PasswordChanged);
        }

        public IResult Delete(User user)
        {
            var result = _userDal.GetById(user.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return result.Count > 0
                ? new SuccessDataResult<List<User>>(result, Messages.UsersListed)
                : new ErrorDataResult<List<User>>(result, Messages.UsersListNotFound);
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.GetById(userId);
            return result != null
                ? new SuccessDataResult<User>(result, Messages.UserGetById)
                : new ErrorDataResult<User>(result, Messages.UserNotFound);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            return result == null
            ? new ErrorDataResult<User>(result, Messages.UserNotFound)
            : new SuccessDataResult<User>(result, Messages.UserGetByMail);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result, Messages.GetUserClaims);
        }

        public IResult Update(User user)
        {
            var currentUser = _userDal.GetById(user.Id);
            if (currentUser == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            var userForUpdate = user;
            userForUpdate.Status = currentUser.Status;
            userForUpdate.PasswordHash = currentUser.PasswordHash;
            userForUpdate.PasswordSalt = currentUser.PasswordSalt;
            _userDal.Update(userForUpdate);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}