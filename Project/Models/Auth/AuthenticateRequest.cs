﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Auth
{
    public class AuthenticateRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
