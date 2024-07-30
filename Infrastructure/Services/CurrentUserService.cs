using Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public async Task<bool> IsInRoleAsync(int userId, string role)
        {
            //var user = await _userManager.FindByIdAsync(userId);

            //return user != null && await _userManager.IsInRoleAsync(user, role);
            return true;
        }

        public async Task<bool> AuthorizeAsync(int userId, string policyName)
        {
            //var user = await _userManager.FindByIdAsync(userId);

            //if (user == null)
            //{
            //    return false;
            //}
            //var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

            //var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            //return result.Succeeded;

            return true;
        }
        public async Task<string?> GetUserNameAsync(int userId)
        {
            //var user = await _userManager.FindByIdAsync(userId);

            //return user?.Username;
            return "Sys";
        }
    }
}
