using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Plans.Commands.UpdatePlan;

public record UpdatePlanCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
}
internal class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand>
{
    private readonly IAppDbContext _context;

    public UpdatePlanCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
       
        var entity = await _context.Plans
            .FindAsync(new object[] { request.Id }, cancellationToken);

      
        Guard.Against.NotFound(request.Id, entity);

       
        entity.Name = request.Name;
        entity.Description = request.Description;

      
        await _context.SaveChangesAsync(cancellationToken);

        
    }
}