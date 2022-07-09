using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using XProject.Shared.Enums;

namespace XProject.Identity.Infrastructure.Entities
{
    public class Account
    {
        [Key]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AccountType AccountType { get; set; }
        public string CompanyId { get; set; }
        public string RoleId { get; set; }
        public bool? Passive { get; set; }
        public bool IsLicenceAccount { get; set; }

    }
}
