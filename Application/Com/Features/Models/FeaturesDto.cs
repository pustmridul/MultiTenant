using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using Application.Com.TenantMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Features.Models
{
    public class FeaturesDto
    {
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
        private class FeatureMapping : Profile
        {
            public FeatureMapping()
            {
                CreateMap<Feature, FeaturesDto>();
               
            }
        }
    }
}
