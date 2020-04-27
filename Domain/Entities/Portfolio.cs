using Flunt.Notifications;
using System;

namespace Domain.Entity
{
    public class Portfolio : Notifiable
    {
        public Portfolio(string name, Guid tenantId)
        {
            Id = Guid.NewGuid();
            Name = name;
            TenantId = tenantId;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid TenantId { get; private set; }

        public virtual Tenant Tenant { get; private set; }
    }
}
