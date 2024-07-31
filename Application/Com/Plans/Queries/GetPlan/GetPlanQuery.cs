using Application.Com.PaymentMethods.Models;
using Application.Com.PaymentMethods.Queries.GetAllPaymentMethod;
using Application.Com.Plans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Plans.Queries.GetPlan;

public record GetPlanQuery : IRequest<PaginatedList<PlanDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetPlanQueryHandler : IRequestHandler<GetPlanQuery, PaginatedList<PlanDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetPlanQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PlanDto>> Handle(GetPlanQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Plans
           .OrderBy(x => x.Name)
           .ProjectTo<PlanDto>(_mapper.ConfigurationProvider)
           .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}