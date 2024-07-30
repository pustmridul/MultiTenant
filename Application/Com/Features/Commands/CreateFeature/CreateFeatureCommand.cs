using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Features.Commands.CreateFeature;

public record CreateFeatureCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
}

internal class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateFeatureCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Feature
            {
                Name = request.Name,
                Description = request.Description
            };

            _context.Features.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;

        }
        catch (Exception ex) { throw new Exception(ex.Message); }

    }    
}