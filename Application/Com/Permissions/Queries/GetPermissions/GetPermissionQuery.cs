using Application.Com.PaymentMethods.Models;
using Application.Com.PaymentMethods.Queries.GetAllPaymentMethod;
using Application.Com.Permissions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Permissions.Queries.GetPermissions;

public record GetPermissionQuery : IRequest<IList<PermissionDto>>
{
}
public class GetPermissionQueryHandler : IRequestHandler<GetPermissionQuery, IList<PermissionDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetPermissionQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<PermissionDto>> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var data= await _context.Permissions
           .OrderBy(x => x.PermissionText)
           .AsNoTracking()
           .ToListAsync( cancellationToken);
            var permissionDtos = data.Select(p => new PermissionDto
            {
                Id = p.Id,
                PermissionText = p.PermissionText,
                PermissionCode = p.PermissionCode
            }).ToList();

            return permissionDtos;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}