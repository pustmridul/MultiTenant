using Application.Com.PaymentMethods.Commands.UpdatePaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Com.PaymentMethods.Models; 

namespace Application.Com.TenantMethods.Commands.UpdateTenantMethod
{
    public record UpdateTenantMethodCommand : IRequest
    {
        public int Id { get; init; }
        public string TenantName { get; init; } = string.Empty;
        public string Domain { get; init; } = string.Empty;
        public string SubscriptionPlan { get; init; } = string.Empty;
        public int StorageQuota { get; init; }
        public int PaymentStatusId { get; init; }
        public string BillingAddress { get; init; } = string.Empty;
        public string ContactPerson { get; init; } = string.Empty;
    }
    internal class UpdateTenantMethodCommandHandler : IRequestHandler<UpdateTenantMethodCommand>
    {
        private readonly IAppDbContext _context;

        private readonly IMapper _mapper;

        public UpdateTenantMethodCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTenantMethodCommand request, CancellationToken cancellationToken)
        {

            var entity = await _context.Tenants
                  .FindAsync(new object[] { request.Id }, cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            _mapper.Map(request, entity);


            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
