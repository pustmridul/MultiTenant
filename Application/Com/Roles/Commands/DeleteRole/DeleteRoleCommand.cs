using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Roles.Commands.DeleteRole;

public record DeleteRoleCommand : IRequest
{
    public int RoleId { get; init; }
}
public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly IAppDbContext _context;

    public DeleteRoleCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles
            .FindAsync(new object[] { request.RoleId }, cancellationToken);

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync(cancellationToken);

       
    }
}