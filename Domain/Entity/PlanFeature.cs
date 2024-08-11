using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class PlanFeature : BaseEntity
    {
       public int PlanId {  get; set; }
       public int FeatureId { get; set; }
        public bool IactiveFeature { get; set; }
        public Plan Plan { get; set; }
        public Feature Feature { get; set; }
    }
}
