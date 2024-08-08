using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Prices.Commands.CreatePrice;

public class CreatePriceCommand : IRequest<int>
{
    public int PlanId { get; init; }
    public decimal Price { get; init; }
}
internal class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand, int>
{
    private readonly IAppDbContext _context;

    public CreatePriceCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
    {
        var plan = await _context.Plans.FindAsync(new object[] { request.PlanId }, cancellationToken);

        try
        {
            var pricing = new Pricing
            {
                PlanId = request.PlanId,
                Price = request.Price,
            };

            _context.Pricings.Add(pricing);
            await _context.SaveChangesAsync(cancellationToken);

            return pricing.Id;
        }

        catch (Exception ex) { throw new Exception(ex.Message); }
    }
}