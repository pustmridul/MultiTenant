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
        public List<PlanFeatureDto> PlanFeatureDtos { get; init; } = new List<PlanFeatureDto>();
        private class PlanMapping : Profile
        {
            public PlanMapping()
            {
                CreateMap<Plan, PlanDto>()
                .ForMember(dest => dest.PlanFeatureDtos, opt => opt.MapFrom(src => src.PlanFeatures)).ReverseMap();

                CreateMap<PlanFeature, PlanFeatureDto>().ReverseMap();

            }
        }
    }

    public class PlanFeatureDto
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int FeatureId { get; set; }
        public bool IactiveFeature { get; set; }
    }
}
