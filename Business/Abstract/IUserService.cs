using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService//: IBaseService<User>
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByEmail(string email);
        IDataResult<UserDto> GetUserByEmail(string email);
        IResult Update(User user);

    }
}
