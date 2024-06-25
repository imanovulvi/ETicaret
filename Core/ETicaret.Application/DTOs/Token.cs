﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.DTOs
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpires { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenDateTime { get; set; }
    }
}