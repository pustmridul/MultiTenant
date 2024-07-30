using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Subscriptions.Commands.CreateSubscription;

public record CreateSubscriptionCommand : IRequest<int>
{
    public string SubscriptionName { get; init; } = string.Empty;
    public string Plan { get; init; } = string.Empty;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public decimal Price { get; init; }
    public int CustomerId { get; init; }
}

//internal class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, int>
//{
//    private readonly IAppDbContext _context;

//    public CreateSubscriptionCommandHandler(IAppDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<int> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
//    {
//        var entity = new Subscription
//        {
//            SubscriptionName = request.SubscriptionName,
//            Plan = request.Plan,
//            StartDate = request.StartDate,
//            EndDate = request.EndDate,
//            Price = request.Price,
//            CustomerId = request.CustomerId
//        };

//        _context.Subscriptions.Add(entity);
//        await _context.SaveChangesAsync(cancellationToken);
//        return entity.Id; // Ensure Subscription entity has an Id property
//    }
//}