using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<UserOperationClaimDto> GetClaims(User user)
        {
            using (var context = new RentACarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new UserOperationClaimDto { UserName = user.FirstName + " " + user.LastName, OperationClaimName = operationClaim.Name, Email = user.Email };
                return result.ToList();

            }
        }
    }
}
