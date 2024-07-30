using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Domain.Entity; 

namespace Application.Com.Invoices.Commands.CreateInvoice
{
    public record CreateInvoiceCommand : IRequest<int>
    {
        public int SubscriptionId { get; init; }
        public DateTime DueDate { get; init; }
        public decimal AmountDue { get; init; }
        public DateTime? IssuedDate { get; init; }
        public int InvoiceStatusId { get; init; }
    }

    internal class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateInvoiceCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            try {
                var entity = new Invoice
                {
                    SubscriptionId = request.SubscriptionId,
                    DueDate = request.DueDate,
                    AmountDue = request.AmountDue,
                    IssuedDate = request.IssuedDate,
                    InvoiceStatusId = request.InvoiceStatusId
                };

                _context.Invoices.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
          
        }
    }
}
