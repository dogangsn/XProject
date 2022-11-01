using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XProject.Identity.Infrastructure.Entities;
using XProject.Shared.Dtos;

namespace XProject.Identity.Infrastructure.Services.Interface
{
    public interface IProfileService
    {
        Task GetProfileDataAsync(ProfileDataRequestContext context);

        Task<Response<string>> CheckUserAccount(ApplicationUser user, string address, string clientId);
    }
}
