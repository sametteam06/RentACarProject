using Core.DataAcceess;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<UserOperationClaimDto> GetClaims(User user);
    }
}
