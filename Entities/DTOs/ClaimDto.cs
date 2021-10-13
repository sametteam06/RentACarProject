using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ClaimDto:IDto
    {
        public int UserOperationClaimId { get; set; }
        public string UserEmail { get; set; }
        public string OperationClaimName { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
