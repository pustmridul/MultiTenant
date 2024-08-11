using Application.Com.PaymentMethods.Models;
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
        try
        {
            return await _context.Products
           .OrderBy(x => x.Name)
           .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
           .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }


    }
}