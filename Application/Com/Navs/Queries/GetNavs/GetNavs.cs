using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Com.Navs.Models;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Application.Com.Navs.Queries.GetAllNav;

public record GetNavsQuery : IRequest<List<NavDto>>
{
}

public class GetNavsQueryHandler : IRequestHandler<GetNavsQuery, List<NavDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetNavsQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<NavDto>> Handle(GetNavsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var navItems = await _context.Navs.ToListAsync(cancellationToken);

            if (navItems == null) {
                return new List<NavDto>();
            }
            else
            {
                return BuildTree(navItems);
            }

        }
        catch (Exception ex) {
            throw new Exception(ex.Message);
        }
       
    }
    private List<NavDto> BuildTree(List<Nav> navItems, int? parentId = null)
    {
        return navItems
            .Where(n => n.ParentId == parentId)
            .Select(n => new NavDto
            {
                Id = n.Id,
                Name = n.Name,
                UrlLink = n.UrlLink,
                ParentId = n.ParentId,
                Children = BuildTree(navItems, n.Id)
            })
            .ToList();
    }
}