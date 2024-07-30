using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PermissionService : IPermissionService
    {
        public bool HasPermission(string role, string permission)
        {
             return false; 
        }
    }
}
