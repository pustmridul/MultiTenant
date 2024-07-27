using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entity
{
    public class User : IdentityUser
    {
        public string Username { get; set; }= string.Empty;
        public int TenantId { get; set; }
        public DateTime LastLogin {  get; set; }
        public bool IsActive { get; set; }
        public string? ProfilePictureURL { get; set; }
    }
}
