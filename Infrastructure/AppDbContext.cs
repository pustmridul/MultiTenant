using Application.Common.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace Infrastructure;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users => Set<User>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
    public DbSet<UserLog> UserLogs => Set<UserLog>();
    public DbSet<Feature> Features => Set<Feature>();
    public DbSet<Plan> Plans => Set<Plan>();
    public DbSet<PlanFeature> PlanFeatures => Set<PlanFeature>();
    public DbSet<Pricing> Pricings => Set<Pricing>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Nav> Navs => Set<Nav>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    public IDbContextTransaction BeginTransaction()
    {
        return Database.BeginTransaction();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return await Database.BeginTransactionAsync(cancellationToken);
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}
