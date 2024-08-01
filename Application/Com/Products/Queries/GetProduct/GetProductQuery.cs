using Application.Com.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Products.Queries.GetProduct;

public record GetProductQuery : IRequest<PaginatedList<ProductDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetProductQueryHandler : IRequestHandler<GetProductQuery, PaginatedList<ProductDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Products
            .AsNoTracking()
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider);

        var totalItems = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedList<ProductDto>(items, totalItems, request.PageNumber, request.PageSize);
    }
}