using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User : BaseEntity
    {
        public string Username { get; set; }= string.Empty;
        public string Email {  get; set; }= string.Empty;
        public int TenantId { get; set; }
        public DateTime LastLogin {  get; set; }
        public bool IsActive { get; set; }
        public string? ProfilePictureURL { get; set; }
    }
}
