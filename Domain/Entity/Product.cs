using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }=string.Empty;
        public string? Description { get; set; }
        public string? PricingModel { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? EndofLifeDate { get; set; }
    }
}
