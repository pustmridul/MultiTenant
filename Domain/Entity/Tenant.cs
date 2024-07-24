using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Tenant : BaseEntity
    {
        public string TenantName { get; set; }= string.Empty;
        public string Domain {  get; set; }=string.Empty;
        public string SubscriptionPlan {  get; set; }= string.Empty;
        public int StorageQuota {  get; set; }
        public int PaymentStatusId { get; set; }
        public string BillingAddress { get; set; } = string.Empty;
        public string ContactPerson {  get; set; }=string.Empty ;
    }
}
