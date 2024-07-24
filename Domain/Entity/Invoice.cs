using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Invoice : BaseEntity
    {
        public int SubscriptionId { get; set; }
        public DateTime DueDate { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime? IssuedDate { get; set; }
        public int InvoiceStatusId { get; set; }
    }
}
