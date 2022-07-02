using System;
using System.Collections.Generic;
using System.Text;

namespace XProject.Identity.Infrastructure.Dtos
{
    public class SignupDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
