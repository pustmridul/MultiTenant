using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using Application.Com.TenantMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.UserLogs.Models;

public class UserLogDto
{
    public int UserId { get; init; }
    public string? Action { get; init; }
    public string? DeviceInfo { get; init; }
    public string? IpAddress { get; init; }

    private class UserLogMapping : Profile
    {
        public UserLogMapping()
        {
            CreateMap<UserLog, UserLogDto>();
           
        }
    }
}
