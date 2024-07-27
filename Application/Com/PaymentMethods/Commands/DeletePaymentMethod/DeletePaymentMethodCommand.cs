using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.PaymentMethods.Commands.DeletePaymentMethod;
public record DeletePaymentMethodCommand(int Id) : IRequest;

internal class DeletePaymentMethodCommandHandler : IRequestHandler<DeletePaymentMethodCommand>
{
    private readonly IAppDbContext _context;

    public DeletePaymentMethodCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.PaymentMethods
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.PaymentMethods.Remove(entity);


        await _context.SaveChangesAsync(cancellationToken);
    }

}

