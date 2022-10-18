using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XProject.Shared.Accounts;

namespace XProject.Identity.Infrastructure.Services
{
    public interface IAccountService
    {
        Task<SignupDto> GetAccountByIdForClaims(string id);
    }
}
