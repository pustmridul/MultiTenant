using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Roles.Commands.UpdateRole;

public record UpdateRoleCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}
internal class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
{
    private readonly IAppDbContext _context;

    private readonly IMapper _mapper;

    public UpdateRoleCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {

        var entity = await _context.Tenants
              .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _mapper.Map(request, entity);


        await _context.SaveChangesAsync(cancellationToken);
    }
}