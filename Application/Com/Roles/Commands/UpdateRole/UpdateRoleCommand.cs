using Application.Com.Permissions.Models;
using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Roles.Commands.UpdateRole;

public record UpdateRoleCommand : IRequest<Result>
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public List<PermissionDto> Permissions { get; init; } = new List<PermissionDto>();
}
internal class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand , Result>
{
    private readonly IAppDbContext _context;

    private readonly IMapper _mapper;

    public UpdateRoleCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        using (var transaction = await _context.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                var role = await _context.Roles
                    .Include(i => i.RolePermissions)
                    .SingleOrDefaultAsync(q => q.Id == request.Id, cancellationToken);

                Guard.Against.NotFound(request.Id, role);


                foreach (var d in request.Permissions)
                {
                    var rolePermission = role.RolePermissions.SingleOrDefault(q=>q.PermissionId== d.Id);
                    if (rolePermission == null) {
                        rolePermission = new RolePermission
                        {
                            RoleId = role.Id,
                            PermissionId = d.Id
                        };
                        _context.RolePermissions.Add(rolePermission);
                    }
                   
                }
                List<RolePermission> toBeDeleted= new List<RolePermission>();

                foreach (var permission in role.RolePermissions) 
                { 

                }

                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return Result.Success();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);

                throw new Exception(ex.Message);
            }

        }
    }
}