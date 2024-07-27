using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Com.PaymentMethods.Models;


namespace Application.Com.PaymentMethods.Queries.GetAllPaymentMethod;

public record GetPaymentMethodsQuery : IRequest<PaginatedList<PaymentMethodDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetPaymentMethodsQueryHandler : IRequestHandler<GetPaymentMethodsQuery, PaginatedList<PaymentMethodDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetPaymentMethodsQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PaymentMethodDto>> Handle(GetPaymentMethodsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.PaymentMethods
           .OrderBy(x => x.Name)
           .ProjectTo<PaymentMethodDto>(_mapper.ConfigurationProvider)
           .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

        }
        catch (Exception ex) {
            throw new Exception(ex.Message);
        }
       
    }
}