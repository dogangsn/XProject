using IdentityServer4.Models;
using System.Collections.Generic;
using System;
using System.Text;
using IdentityServer4;

namespace XProject.Identity.Infrastructure
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("resource_account"){Scopes = {"accountapi"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };


        public static IEnumerable<IdentityResource> IdentityResources =>
             new IdentityResource[]
             {
             };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("accountapi","Account Api"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
           new Client[]
           {
               new Client
               {
                   ClientName = "XProject",
                   ClientId = "ClientAPI",
                   ClientSecrets = { new Secret("secret".Sha256()) },
                   AllowedGrantTypes= GrantTypes.ClientCredentials,
                   AllowedScopes = { "accountapi" , IdentityServerConstants.LocalApi.ScopeName }
               }
           };


    }
}
