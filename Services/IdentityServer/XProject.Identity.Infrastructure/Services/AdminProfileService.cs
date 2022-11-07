﻿using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XProject.Identity.Infrastructure.Entities;
using XProject.Identity.Infrastructure.Services.Interface;
using XProject.Shared.Accounts;
using XProject.Shared.Dtos;

namespace XProject.Identity.Infrastructure.Services
{
    public class AdminProfileService : IProfileService
    {

        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminProfileService(IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IAccountService accountService, UserManager<ApplicationUser> userManager)
        {
            _claimsFactory = claimsFactory;
            _accountService = accountService;
            _userManager = userManager;
        }

        public AdminProfileService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var subjectId = context.Subject.GetSubjectId();
                var method = context.Subject.GetAuthenticationMethod();
                if (method == "pwd")
                {
                    var claims = context.IssuedClaims;
                    var user = await _userManager.FindByIdAsync(subjectId);
                    if (user != null)
                    {
                        var principal = await _claimsFactory.CreateAsync(user);
                        var account = await _accountService.GetAccountByIdForClaims(subjectId);
                        if (account != null)
                        {
                            var accountClaims = CreateClaims(account);
                            claims.AddRange(principal.Claims.ToList());
                            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
                            claims.AddRange(accountClaims);
                            claims.Add(new Claim(JwtClaimTypes.Id, user.Id));
                            claims.Add(new Claim("UserName", user.UserName));
                            claims.Add(new Claim(JwtClaimTypes.ClientId, context.Client.ClientId));
                            claims.Add(new Claim(JwtClaimTypes.IssuedAt, DateTime.Now.ToString()));
                            context.IssuedClaims = claims;
                        }
                    }
                }
                if (method == "delegation")
                {
                    context.IssuedClaims.AddRange(context.Subject.Claims);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<Claim> CreateClaims(SignupDto account)
        {
            string sql = "Data Source=admin-sql.clrcwaxozgvw.eu-central-1.rds.amazonaws.com;Initial Catalog=MasterDb;User Id=kodmaster;Password=Xi17p!657hg;Persist Security Info = True";
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("CompanyId", account.CompanyId));
            claims.Add(new Claim("FirstName", account.FirstName));
            claims.Add(new Claim("LastName", account.LastName));
            claims.Add(new Claim("AccountType", account.AccountType.ToString()));
            claims.Add(new Claim("TenantId", account.TenantId.ToString()));
            claims.Add(new Claim("ConnectionDb", sql));
            claims.Add(new Claim("UseSafeListControl", account.UseSafeListControl ? "1" : "0"));
            claims.Add(new Claim("RoleId", account.RoleId.ToString()));
            claims.Add(new Claim("Host", account.Host.ToString()));
            //claims.Add(new Claim("SubscriptionType", Convert.ToInt32(account.SubscriptionType).ToString()));
            claims.Add(new Claim("CurrencyCode", account.CurrencyCode));
            claims.Add(new Claim("DefaultLanguage", account.DefaultLanguage));
            //string module = string.Empty;
            //if (account.Modules.Any())
            //{
            //    module = JsonConvert.SerializeObject(account.Modules);
            //}
            //claims.Add(new Claim("Modules", module));
            return claims;
        }

        public async Task<Response<string>> CheckUserAccount(ApplicationUser user, string address, string clientId)
        {
            var response = new Response<string>
            {
                ResponseType = ResponseType.Ok
            };
            var account = await _accountService.GetAccountByIdForClaims(user.Id);
            if (account != null /*&& account.IsLicenceAccount*/)
            {
                response.ResponseType = ResponseType.Error;
                response.Data = "Giriş yetkisi yok";
                return response;
            }

            //if (account.UseSafeListControl)
            //{
            //    var control = await _accountService.CheckSafeList(account.CompanyId, address);
            //    if (control != null && control.ResponseType == ResponseType.Error)
            //    {
            //        response.ResponseType = ResponseType.Error;
            //        response.Data = control.Message;

            //        _logger.LogError(control.Message);
            //    }
            //}

            return response;
        }
    }
}
