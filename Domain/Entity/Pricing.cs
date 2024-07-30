using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Pricing : BaseEntity
    {
        public int PlanId { get; set; }
        public decimal Price { get; set; }
    }
}
