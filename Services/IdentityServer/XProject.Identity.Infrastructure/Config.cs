using IdentityServer4.Models;
using System.Collections.Generic;
using System;
using System.Text;

namespace XProject.Identity.Infrastructure
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
             new IdentityResource[]
             {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
             };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
            };

        public static IEnumerable<Client> Clients =>
           new Client[]
           {

           };


    }
}
