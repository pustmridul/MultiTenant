using Application.Com.Plans.Models;

namespace Application.Com.Plans.Commands.CreatePlan;

public record CreatePlanCommand : IRequest<Result>
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public List<PlanFeatureDto> PlanFeatureDtos { get; init; } = new List<PlanFeatureDto>();

}
internal class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, Result>
{
    private readonly IAppDbContext _context;

    public CreatePlanCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {

        using (var transaction = await _context.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                var obj = new Plan
                {
                    Name = request.Name,
                    Description = request.Description,
                };
                _context.Plans.Add(obj);
                await _context.SaveChangesAsync(cancellationToken);
                foreach (var d in request.PlanFeatureDtos)
                {
                    var detail = new PlanFeature
                    {
                        PlanId = obj.Id,
                        FeatureId = d.Id,
                        IactiveFeature = d.IactiveFeature,
                    };
                    _context.PlanFeatures.Add(detail);
                }

                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return Result.Success();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);

                throw new Exception(ex.Message);
            }

        }
    }
}