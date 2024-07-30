using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Plans.Commands.CreatePlan;

public record CreatePlanCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
}
internal class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, int>
{
    private readonly IAppDbContext _context;

    public CreatePlanCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        var entity = new Plan
        {
            Name = request.Name,
            Description = request.Description,
            Pricings = new List<Pricing>(), // Initialize collections
            PlanFeatures = new List<PlanFeature>() // Initialize collections
        };

        _context.Plans.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}