using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Payment : BaseEntity
    {
        public int SubscriptionId {  get; set; }    
        public decimal Amount { get; set; }
        public DateTime PaymentDate  { get; set; }
        public int PaymentMethodId { get; set; }
        public int PaymentStatusId { get; set; }
        public int InvoiceId { get; set; }
    }
}
