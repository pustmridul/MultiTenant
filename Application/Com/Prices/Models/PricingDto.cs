using Application.Com.Plans.Models;
using Application.Com.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Prices.Models;

public class PricingDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    private class PriceMapping : Profile
    {
        public PriceMapping()
        {
            CreateMap<Pricing, PricingDto>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Plan.Name))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Plan.Description));

        }
    }
}
