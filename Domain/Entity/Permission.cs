using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Permission : BaseEntity
    {
        public string PermissionCode { get; set; } = string.Empty;
        public string PermissionText { get; set; }= string.Empty;

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
