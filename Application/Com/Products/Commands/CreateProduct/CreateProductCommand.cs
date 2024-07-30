using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
namespace Application.Com.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<int>
{
    public string ProductName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public string? PricingModel { get; init; }
    public bool IsActive { get; init; }
    public DateTime? ReleaseDate { get; init; }
    public DateTime? EndofLifeDate { get; init; }
}
internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateProductCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Product
            {
                ProductName = request.ProductName,
                Description = request.Description,
                PricingModel = request.PricingModel,
                IsActive = request.IsActive,
                ReleaseDate = request.ReleaseDate,
                EndofLifeDate = request.EndofLifeDate
            };

            _context.Products.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }
}