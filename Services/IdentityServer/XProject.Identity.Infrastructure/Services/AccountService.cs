using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XProject.Shared.Accounts;

namespace XProject.Identity.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        public Task<SignupDto> GetAccountByIdForClaims(string id)
        {
            throw new NotImplementedException();
        }
    }
}
