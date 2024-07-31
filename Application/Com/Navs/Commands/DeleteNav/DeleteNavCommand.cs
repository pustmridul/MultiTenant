using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Navs.Commands.DeleteNav;
public record DeleteNavCommand(int Id) : IRequest;

internal class DeleteNavCommandHandler : IRequestHandler<DeleteNavCommand>
{
    private readonly IAppDbContext _context;

    public DeleteNavCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteNavCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Navs
            .SingleOrDefaultAsync(q=> q.Id==request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Navs.Remove(entity);


        await _context.SaveChangesAsync(cancellationToken);
    }

}

