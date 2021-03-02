using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

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
    }
}
