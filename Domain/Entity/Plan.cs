﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Plan : BaseEntity
    {
        public string Name { get; set; }= string.Empty;
        public string? Description { get; set; } 
        public ICollection<Pricing> Pricings { get; set; }
        public ICollection<PlanFeature> PlanFeatures { get; set; }

    }
}
