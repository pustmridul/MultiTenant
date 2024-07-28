using Application.Com.PaymentMethods.Commands.DeletePaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.TenantMethods.Commands.DeleteTenantMethod;

public record DeleteTenantMethodCommand(int tenantId): IRequest;

internal class DeleteTenentMethodCommandHandler : IRequestHandler<DeleteTenantMethodCommand>
{
    private readonly IAppDbContext _context;

    public DeleteTenentMethodCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTenantMethodCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tenants
            .FindAsync(new object[] { request.tenantId }, cancellationToken);

        Guard.Against.NotFound(request.tenantId, entity);

        _context.Tenants.Remove(entity);


        await _context.SaveChangesAsync(cancellationToken);
    }

}