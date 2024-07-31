using Application.Com.Features.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Features.Queries.GetFeature;

public record GetFeatureQuery : IRequest<PaginatedList<FeaturesDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetFeatureQuerieHandler : IRequestHandler<GetFeatureQuery, PaginatedList<FeaturesDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetFeatureQuerieHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<FeaturesDto>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
    {
        try
        {
           
            return await _context.Features
                .OrderBy(x => x.Name) 
                .ProjectTo<FeaturesDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        }
        catch (Exception ex)
        {
            
            throw new Exception("An error occurred while retrieving the features.", ex);
        }
    }
}