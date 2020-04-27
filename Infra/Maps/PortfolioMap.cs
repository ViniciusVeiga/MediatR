using Domain.Entity;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class PortfolioMap : IEntityTypeConfiguration<Portfolio>
    {
        private readonly InfraContext _context;

        public PortfolioMap(InfraContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Ignore(e => e.Notifications);

            builder.HasOne(e => e.Tenant).WithMany(e => e.Portfolios).HasForeignKey(e => e.TenantId);
            builder.HasQueryFilter(e => e.TenantId == _context.TenantProvider.GetTenantId());

            builder.ToTable("Portfolios");
        }
    }
}
