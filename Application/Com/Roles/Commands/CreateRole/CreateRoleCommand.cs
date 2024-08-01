using Application.Com.Permissions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Roles.Commands.CreateRole;

public record CreateRoleCommand : IRequest<Result>
{
    public string Name { get; init; } = string.Empty;
    public List<PermissionDto> Permissions { get; init; } = new List<PermissionDto>();

}
public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Result>
{
    private readonly IAppDbContext _context;

    public CreateRoleCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {

            using (var transaction = await _context.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var role = new Role
                    {
                        Name = request.Name
                    };
                    _context.Roles.Add(role);
                    await _context.SaveChangesAsync(cancellationToken);
                    foreach (var d in request.Permissions)
                    {
                        var rolePermission = new RolePermission
                        {
                            RoleId = role.Id, 
                            PermissionId = d.Id
                        };
                        _context.RolePermissions.Add(rolePermission);
                    }

                    await _context.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync(cancellationToken);
                    return Result.Success();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);

                     throw  new Exception(ex.Message); }
                    
                }
            }
    
}
