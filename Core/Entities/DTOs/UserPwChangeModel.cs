using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.DTOs
{
    public class UserPwChangeModel
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string PasswordCheck { get; set; }
    }
}
