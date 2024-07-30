using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.UserLogs.Commands.CreateUsageLog;

public record CreateUsageLogCommand : IRequest<int>
{
    public int UserId { get; init; }
    public string? Action { get; init; }
    public string? DeviceInfo { get; init; }
    public string? IpAddress { get; init; }
}
internal class CreateUsageLogCommandHandler : IRequestHandler<CreateUsageLogCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateUsageLogCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateUsageLogCommand request, CancellationToken cancellationToken)
    {
        var entity = new UserLog
        {
            UserId = request.UserId,
            Action = request.Action,
            DeviceInfo = request.DeviceInfo,
            IpAddress = request.IpAddress
        };

        _context.UserLogs.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.UserId;
    }
}