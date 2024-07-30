using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.UserLogs.Commands.CreateUserLog;

public record CreateUserLogCommands : IRequest<int>
{
    public int UserId { get; init; }
    public string? Action { get; init; }
    public string? DeviceInfo { get; init; }
    public string? IpAddress { get; init; }
}
internal class CreateUserLogCommandHandler : IRequestHandler<CreateUserLogCommands, int>
{
    private readonly IAppDbContext _context;

    public CreateUserLogCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateUserLogCommands request, CancellationToken cancellationToken)
    {
        try
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
        catch (Exception ex) { throw new Exception(ex.Message); }
    }
}