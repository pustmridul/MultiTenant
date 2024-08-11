using Application.Com.Products.Commands.DeleteProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Prices.Commands.DeletePrice;

public record DeletePriceCommand(int Id):IRequest;


internal class DeletePriceCommandHandler : IRequestHandler<DeletePriceCommand>
{
    private readonly IAppDbContext _context;

    public DeletePriceCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeletePriceCommand request, CancellationToken cancellationToken)
    {

        var entity = await _context.Pricings
            .FindAsync(new object[] { request.Id }, cancellationToken);


        Guard.Against.NotFound(request.Id, entity);


        _context.Pricings.Remove(entity);


        await _context.SaveChangesAsync(cancellationToken);


    }
}