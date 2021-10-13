using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserClaimListDto:IDto
    {
        public string UserEmail { get; set; }
        public List<string>? OperationClaimName { get; set; }
        public int UserId { get; set; }
        public List<int>? OperationClaimId { get; set; }
    }
}
