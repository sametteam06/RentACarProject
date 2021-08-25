using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.DTOs
{
    public class UserOperationClaimDto:IDto
    {
        public string UserName { get; set; }
        public string OperationClaimName { get; set; }
        public string Email { get; set; }
    }
}
