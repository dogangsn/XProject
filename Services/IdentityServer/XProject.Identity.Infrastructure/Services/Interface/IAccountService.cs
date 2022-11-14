using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XProject.Shared.Accounts;

namespace XProject.Identity.Infrastructure.Services.Interface
{
    public interface IAccountService
    {
        Task<SignupDto> GetAccountByIdForClaims(string id);
    }
}
