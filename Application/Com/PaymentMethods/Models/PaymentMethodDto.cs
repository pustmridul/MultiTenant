using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.PaymentMethods.Models;
public class PaymentMethodDto
{
    public int Id { get; init; }
    public string? Name { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PaymentMethod, PaymentMethodDto>();
        }
    }
}