using Application.Com.Permissions.Models;
using Application.Com.Roles.Commands.UpdateRole;
using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using Application.Com.TenantMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Roles.Models;

public class RoleDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public List<PermissionDto> Permissions { get; init; } = new List<PermissionDto>();
    private class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<UpdateRoleCommand, Role>();
        }
    }
}



