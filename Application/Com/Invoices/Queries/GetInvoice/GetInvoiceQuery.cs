using Application.Com.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Invoices.Queries.GetInvoice;

public record GetInvoiceQuery : IRequest<PaginatedList<InvoiceDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, PaginatedList<InvoiceDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetInvoiceQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<InvoiceDto>> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Invoices
            .AsNoTracking()
            .ProjectTo<InvoiceDto>(_mapper.ConfigurationProvider);

        var totalItems = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedList<InvoiceDto>(items, totalItems, request.PageNumber, request.PageSize);
    }
}