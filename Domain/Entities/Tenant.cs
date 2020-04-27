using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Tenant
    {
        public Tenant(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        public IList<Portfolio> Portfolios { get; private set; }
    }
}
