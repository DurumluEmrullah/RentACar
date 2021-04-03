using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager:IAuthService
    {

        private IUserService _userService;
        private ITokenHelper _toknHelper;

        public AuthManager(IUserService userService, ITokenHelper toknHelper)
        {
            _userService = userService;
            _toknHelper = toknHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordHash,out passwordSalt);
            var user = new User()
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            return new SuccessDataResult<User>(user, Messages.UserAdded);

        }

        public IDataResult<UserDto> GetUserByEmail(string email)
        {
            var result =_userService.GetUserByEmail(email);
            if (result.Success)
            {
                return new SuccessDataResult<UserDto>(result.Data);
            }

            return new ErrorDataResult<UserDto>(result.Message);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFind);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash,
                userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);

            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessLogin);
        }


        public IResult UserExists(string email)
        {
            var result = _userService.GetByEmail(email);

            if (result == null)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.UserAlreadyExists);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _toknHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);

        }

        public IDataResult<User> Update(UserForUpdateDto userForUpdateDto)
        {
            var userToCheck = _userService.GetByEmail(userForUpdateDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFind);
            }

            if (!HashingHelper.VerifyPasswordHash(userForUpdateDto.LastPassword, userToCheck.Data.PasswordHash,
                userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);

            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForUpdateDto.NewPassword, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Id= userForUpdateDto.Id,
                FirstName = userForUpdateDto.FirstName,
                LastName = userForUpdateDto.LastName,
                Email = userForUpdateDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Update(user);
            return new SuccessDataResult<User>(Messages.UserUpdated);
        }
    }
}
