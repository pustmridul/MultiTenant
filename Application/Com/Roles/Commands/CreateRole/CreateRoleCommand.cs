using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Roles.Commands.CreateRole;

public record CreateRoleCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
}
public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateRoleCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        try {
            var role = new Role
            {
                Name = request.Name
            };

            _context.Roles.Add(role);
            await _context.SaveChangesAsync(cancellationToken);

            return role.Id;
        } 
        catch (Exception ex) { throw new Exception(ex.Message); }
    }
}
