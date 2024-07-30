using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Features.Commands.DeleteFeature;

public record DeleteFeatureCommand(int Id) : IRequest;
internal class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand>
{
    private readonly IAppDbContext _context;

    public DeleteFeatureCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Features
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Features.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

       
    }
}