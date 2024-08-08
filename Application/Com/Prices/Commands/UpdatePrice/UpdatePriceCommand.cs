using Application.Com.Prices.Commands.CreatePrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Prices.Commands.UpdatePrice;

public class UpdatePriceCommand:IRequest<int>
{
public int Id { get; init; }
public int PlanId { get; init; }
public decimal Price { get; init; }
 
}
public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand,int>
{
    private readonly IAppDbContext _context;

    public UpdatePriceCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Pricing
            {
                PlanId = request.PlanId,
                Price = request.Price
            };

            _context.Pricings.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
