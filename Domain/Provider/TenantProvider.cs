using System;

namespace Domain.Provider
{
    public class TenantProvider
    {
        private Guid id;

        public TenantProvider(Guid id)
        {
            this.id = id;
        }

        public Guid GetTenantId() => id;
    }
}
