using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Task<bool> IsInRoleAsync (int userId,string roleName);
        Task<bool> AuthorizeAsync(int userId, string policy);
        Task<string?> GetUserNameAsync(int userId);

    }
}
