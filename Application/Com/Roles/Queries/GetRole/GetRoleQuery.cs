using Application.Com.Roles.Models;
using Application.Com.TenantMethods.Models;
using Application.Com.TenantMethods.Queries.GetTenantMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Roles.Queries.GetRole;

public record GetRoleQuery : IRequest<PaginatedList<RoleDto>>
{
     public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
internal class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, PaginatedList<RoleDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetRoleQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<RoleDto>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Roles
           .OrderBy(x => x.Name)
           .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
           .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}