using Application.Com.Navs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Navs.Commands.CreateNav;

public record CreateNavCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string? UrlLink { get; set; }
    public int? ParentId { get; set; }
}

internal class CreateNavCommandHandler : IRequestHandler<CreateNavCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateNavCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateNavCommand request, CancellationToken cancellationToken)
    {
        var entity = new Nav
        {
            Name = request.Name,
            ParentId = request.ParentId,
            UrlLink = request.UrlLink,
        };

        _context.Navs.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}