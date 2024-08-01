using Application.Com.Permissions.Models;
using Application.Com.Roles.Models;
using Application.Com.TenantMethods.Models;
using Application.Com.TenantMethods.Queries.GetTenantMethods;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Roles.Queries.GetRole;

public record GetRolesQuery : IRequest<IList<RoleDto>>
{
}
internal class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, IList<RoleDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetRolesQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var data= await _context.Roles
            .Include(u => u.RolePermissions.Select(s=>s.Permission))
            .AsNoTracking()
            .ToListAsync();

            var dtos = data.Select(p => new RoleDto
            {
                Id = p.Id,
                Name = p.Name,
                Permissions = p.RolePermissions
                .Select(s=>new PermissionDto
                {
                    Id=s.Id,
                    PermissionCode = s.Permission.PermissionCode,
                    PermissionText = s.Permission.PermissionText
                }
                ).ToList()
            }).ToList();

            return dtos;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}