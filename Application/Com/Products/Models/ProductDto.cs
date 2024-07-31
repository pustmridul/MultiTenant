using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Products.Models
{
    public class ProductDto
    {   
        public int Id { get; set; }
        public string ProductName { get; init; } = string.Empty;
        public string? Description { get; init; }
        public string? PricingModel { get; init; }
        public bool IsActive { get; init; }
        public DateTime? ReleaseDate { get; init; }
        public DateTime? EndofLifeDate { get; init; }
    }
}
