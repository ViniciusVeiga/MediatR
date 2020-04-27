using Domain.Entity;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infra.Repositories
{
    public class TenantRepository
    {
        private readonly InfraContext _context;

        public TenantRepository(InfraContext context)
        {
            _context = context;
        }

        public Tenant[] GetTenants()
        {
            return _context
                .Tenants
                .AsNoTracking()
                .ToArray();
        }
    }
}
