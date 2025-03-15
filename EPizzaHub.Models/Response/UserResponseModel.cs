﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Models.Response
{
    public class UserResponseModel
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    public class ValidateuserResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public List<string> Roles { get; set; }
    }
}
