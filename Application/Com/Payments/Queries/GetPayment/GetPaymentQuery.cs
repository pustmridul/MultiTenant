using Application.Com.Payments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Payments.Queries.GetPayment;

public record GetPaymentQuery : IRequest<PaginatedList<PaymentDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, PaginatedList<PaymentDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetPaymentQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PaymentDto>> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Payments
            .AsNoTracking()
            .ProjectTo<PaymentDto>(_mapper.ConfigurationProvider);

        var totalItems = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedList<PaymentDto>(items, totalItems, request.PageNumber, request.PageSize);
    }
}
