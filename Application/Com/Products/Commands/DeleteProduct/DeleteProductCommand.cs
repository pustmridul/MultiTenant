using Application.Com.Plans.Commands.DeletePlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest;
internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IAppDbContext _context;

    public DeleteProductCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {

        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);


        Guard.Against.NotFound(request.Id, entity);


        _context.Products.Remove(entity);


        await _context.SaveChangesAsync(cancellationToken);


    }
}