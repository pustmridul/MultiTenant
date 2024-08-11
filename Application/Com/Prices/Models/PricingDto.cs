
namespace Application.Com.Prices.Models;

public class PricingDto
{
    public string Name { get; set; }=string.Empty;
    public string Description { get; set; } = string.Empty;
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
