using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.DTOs
{
    public class UserNameChangeModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
