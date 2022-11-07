using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XProject.Shared.Contracts;
using XProject.Shared.Dtos;

namespace XProject.Identity.Application.Services
{
    public interface IAccountDataService
    {
        Task<Response<bool>> SendAsync(string path, ICreateSubscriptionRequestEvent model);
    }
}
