using Microsoft.EntityFrameworkCore;

namespace Application.Com.Prices.Commands.UpdatePrice;

public class UpdatePriceCommand:IRequest<Result>
{
public int Id { get; init; }
public int PlanId { get; init; }
public decimal Price { get; init; }
 
}
public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand, Result>
{
    private readonly IAppDbContext _context;

    public UpdatePriceCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity= await _context.Pricings
                .SingleOrDefaultAsync(q=>q.Id== request.Id , cancellationToken);
            if (entity == null)
            {
                Guard.Against.NotFound(request.Id, entity);

            }
            entity.Price = request.Price;
            entity.PlanId = request.PlanId;
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
