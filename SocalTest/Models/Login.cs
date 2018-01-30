﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialTest.Models
{
    public class LoginInfo
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
    }
}