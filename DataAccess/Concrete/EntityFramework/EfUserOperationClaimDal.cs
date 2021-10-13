using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Entities.DTOs;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, RentACarContext>, IUserOperationClaimDal
    {
        public List<ClaimDto> GetDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from uoc in context.UserOperationClaims
                             join u in context.Users
                             on uoc.UserId equals u.Id
                             join o in context.OperationClaims
                             on uoc.OperationClaimId equals o.Id
                             select new ClaimDto { UserEmail = u.Email, OperationClaimName = o.Name, UserOperationClaimId = uoc.Id, OperationClaimId = uoc.OperationClaimId, UserId = uoc.UserId };
                return result.ToList();
            }
        }
    }
}

