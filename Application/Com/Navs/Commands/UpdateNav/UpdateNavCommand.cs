using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Navs.Commands.UpdateNav;

public record UpdateNavCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}

internal class UpdateNavCommandHandler : IRequestHandler<UpdateNavCommand>
{
    private readonly IAppDbContext _context;

    public UpdateNavCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateNavCommand request, CancellationToken cancellationToken)
    {
 
        var entity = await _context.Navs
              .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}