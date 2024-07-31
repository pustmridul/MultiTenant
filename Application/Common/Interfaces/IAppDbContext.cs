
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
        DbSet<Feature> Features { get; }
        DbSet<Plan> Plans { get; }
        DbSet<PlanFeature> PlanFeatures { get; }
        DbSet<Pricing> Pricings { get; }
        DbSet<Role> Roles { get; }
        DbSet<UserRole> UserRoles { get; }
        DbSet<Nav> Navs { get; }



        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
      
    }
}
