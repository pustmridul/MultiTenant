using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Application.Com.Payments.Commands.CreatePayment;

public record CreatePaymentCommand : IRequest<int>
{
    public int SubscriptionId { get; init; }
    public decimal Amount { get; init; }
    public DateTime PaymentDate { get; init; }
    public int PaymentMethodId { get; init; }
    public int PaymentStatusId { get; init; }
    public int InvoiceId { get; init; }
}
internal class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
{
    private readonly IAppDbContext _context;

    public CreatePaymentCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Payment
        {
            SubscriptionId = request.SubscriptionId,
            Amount = request.Amount,
            PaymentDate = request.PaymentDate,
            PaymentMethodId = request.PaymentMethodId,
            PaymentStatusId = request.PaymentStatusId,
            InvoiceId = request.InvoiceId
        };

        _context.Payments.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
