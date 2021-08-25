using Core.Entities.Concrete;
using Core.Utilities.JWT;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.DTOs;

namespace Core.Utilities.Helper.TokenHelper
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<UserOperationClaimDto> operationClaims);
    }
}
