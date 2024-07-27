using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.PaymentMethods.Commands.UpdatePaymentMethod;

public record UpdatePaymentMethodCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}

internal class UpdateBillerCommandHandler : IRequestHandler<UpdatePaymentMethodCommand>
{
    private readonly IAppDbContext _context;

    public UpdateBillerCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
 
        var entity = await _context.PaymentMethods
              .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}