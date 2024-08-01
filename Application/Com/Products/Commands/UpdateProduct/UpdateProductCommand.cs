using Application.Com.Plans.Commands.UpdatePlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Products.Commands.UpdateProduct;

public record UpdateProductCommand: IRequest
{   public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
}
internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IAppDbContext _context;

    public UpdateProductCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {

        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);


        Guard.Against.NotFound(request.Id, entity);


        entity.Name = request.Name;
        entity.Description = request.Description;


        await _context.SaveChangesAsync(cancellationToken);


    }
}