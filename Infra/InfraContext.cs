using Domain.Entity;
using Domain.Provider;
using Infra.Map;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class InfraContext : DbContext
    {
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<Portfolio> Portfolios { get; set; }

        public TenantProvider TenantProvider { get; private set; }

        public InfraContext(
            DbContextOptions<InfraContext> options,
            TenantProvider tenantProvider) : base(options)
        {
            TenantProvider = tenantProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TenantMap());
            modelBuilder.ApplyConfiguration(new PortfolioMap(this));
        }
    }
}
