using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Features.Commands.UpdateFeature;

public record UpdateFeatureCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
}
internal class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
{
    private readonly IAppDbContext _context;

    public UpdateFeatureCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Features
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

       
    }
}
