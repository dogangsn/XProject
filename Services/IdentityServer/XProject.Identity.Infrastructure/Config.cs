﻿using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System;
using System.Text;

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
                new IdentityResources.Email(),
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
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
               },
               new Client
               {
                   ClientName = "AdminAPI",
                   ClientId = "adminclient",
                   ClientSecrets = { new Secret("secret".Sha256()) },
                   AllowOfflineAccess = true,
                   AlwaysIncludeUserClaimsInIdToken =true,
                   AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                   AllowedScopes = { "accountapi" , IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.OfflineAccess, IdentityServerConstants.LocalApi.ScopeName },
                   AccessTokenLifetime=43200,
                   UpdateAccessTokenClaimsOnRefresh=true,
                   RefreshTokenExpiration=TokenExpiration.Absolute,
                   AbsoluteRefreshTokenLifetime= (int) (DateTime.Now.AddDays(30)- DateTime.Now).TotalSeconds,
                   RefreshTokenUsage= TokenUsage.ReUse
               }
           };


    }
}
