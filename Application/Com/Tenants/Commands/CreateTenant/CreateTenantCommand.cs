using Application.Com.PaymentMethods.Commands.CreatePaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.TenantMethods.Commands.CreateTenantMethod;

public record CreateTenantCommand : IRequest<int>
{
    public string TenantName { get; init; } = string.Empty;
    public string Domain { get; init; } = string.Empty;
    public string SubscriptionPlan { get; init; } = string.Empty;
    public int StorageQuota { get; init; }
    public int PaymentStatusId { get; init; }
    public string BillingAddress { get; init; } = string.Empty;
    public string ContactPerson { get; init; } = string.Empty;
}

internal class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateTenantCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var entity = new Tenant
        {
            TenantName = request.TenantName,
            Domain = request.Domain,
            SubscriptionPlan = request.SubscriptionPlan,
            StorageQuota = request.StorageQuota,
            PaymentStatusId = request.PaymentStatusId,
            BillingAddress = request.BillingAddress,
            ContactPerson = request.ContactPerson,
        };

        _context.Tenants.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}