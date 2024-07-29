using Application.Com.PaymentMethods.Models;
using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.TenantMethods.Models;

public class TenantDto
{  
    public int id {  get; init; }
    public string TenantName { get; init; } = string.Empty;
    public string Domain { get; init; } = string.Empty;
    public string SubscriptionPlan { get; init; } = string.Empty;
    public int StorageQuota { get; init; }
    public int PaymentStatusId { get; init; }
    public string BillingAddress { get; init; } = string.Empty;
    public string ContactPerson { get; init; } = string.Empty;
    private class TenantMapping : Profile
    {
        public TenantMapping()
        {
            CreateMap<Tenant, TenantDto>();
            CreateMap<UpdateTenantMethodCommand, Tenant>();
        }
    }
}
