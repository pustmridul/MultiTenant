
namespace Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; }
        DbSet<PaymentMethod> PaymentMethods { get; }
        DbSet<Tenant> Tenants { get; }
        DbSet<Invoice> Invoices { get; }
        DbSet<Payment> Payments { get; }
        DbSet<Product> Products { get; }
        DbSet<Subscription> Subscriptions { get; }
        DbSet<UserLog> UserLogs { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
      
    }
}
