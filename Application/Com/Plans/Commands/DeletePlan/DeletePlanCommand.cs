using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Plans.Commands.DeletePlan;

public record DeletePlanCommand(int Id) : IRequest;
internal class DeletePlanCommandHandler : IRequestHandler<DeletePlanCommand>
{
    private readonly IAppDbContext _context;

    public DeletePlanCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeletePlanCommand request, CancellationToken cancellationToken)
    {
        
        var entity = await _context.Plans
            .FindAsync(new object[] { request.Id }, cancellationToken);

     
        Guard.Against.NotFound(request.Id, entity);

        
        _context.Plans.Remove(entity);

       
        await _context.SaveChangesAsync(cancellationToken);

        
    }
}