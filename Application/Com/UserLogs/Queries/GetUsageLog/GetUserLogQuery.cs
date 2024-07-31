using Application.Com.UserLogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.UsageLog.Queries.GetUsageLog;

public record GetUserLogQuery : IRequest<PaginatedList<UserLogDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetUsageLogQueryHandler : IRequestHandler<GetUserLogQuery, PaginatedList<UserLogDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetUsageLogQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<UserLogDto>> Handle(GetUserLogQuery request, CancellationToken cancellationToken)
    {
        var query = _context.UserLogs
            .AsNoTracking()
            .ProjectTo<UserLogDto>(_mapper.ConfigurationProvider);

        var totalItems = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedList<UserLogDto>(items, totalItems, request.PageNumber, request.PageSize);
    }
}