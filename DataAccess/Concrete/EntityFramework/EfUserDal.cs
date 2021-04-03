using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,DataBaseContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DataBaseContext())
            {
                var result = from opc in context.OperationClaims
                    join uopc in context.UserOperationClaims
                        on opc.Id equals uopc.OperationClaimId
                    where uopc.Id == user.Id
                    select new OperationClaim() {Id = opc.Id, Name = opc.Name};

                return result.ToList();
            }
        }

        public UserDto GetUserByEmail(string email)
        {
            using (var context = new DataBaseContext())
            {
                var result = from user in context.Users
                             where user.Email.Trim().Equals(email) 
                             select new UserDto() { Id = user.Id, FirstName = user.FirstName,LastName=user.LastName,Email=user.Email};

                return result.FirstOrDefault();
            }
        }
    }
}
