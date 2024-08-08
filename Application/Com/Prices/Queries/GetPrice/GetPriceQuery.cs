using Application.Com.Prices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Prices.Queries.GetPrice;

public class GetPriceQuery : IRequest<PaginatedList<PricingDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetPriceQueryHandler : IRequestHandler<GetPriceQuery, PaginatedList<PricingDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetPriceQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PricingDto>> Handle(GetPriceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _context.Pricings
                .Include(p => p.Plan) 
                .OrderBy(x => x.PlanId)
                .ProjectTo<PricingDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

            return await query;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}