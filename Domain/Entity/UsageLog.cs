using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class UsageLog
    {
        public int UserId { get; set; }
        public string? Action {  get; set; }
        public string? DeviceInfo { get; set; }
        public string? IpAddress { get; set; }

    }
}
