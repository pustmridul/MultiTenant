using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using Application.Com.TenantMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Plans.Models
{
    public class PlanDto
    {
        public int Id { get; set; }
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }

        private class PlanMapping : Profile
        {
            public PlanMapping()
            {
                CreateMap<Plan, PlanDto>();                
            }
        }
    }
}
