using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.PaymentMethods.Commands.CreatePaymentMethod;

public record CreatePaymentMethodCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
}

internal class CreateBillerCommandHandler : IRequestHandler<CreatePaymentMethodCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateBillerCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var entity = new PaymentMethod
        {
            Name = request.Name
        };

        _context.PaymentMethods.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}