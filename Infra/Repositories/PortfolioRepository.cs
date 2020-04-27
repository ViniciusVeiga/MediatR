using Domain.Entity;
using Domain.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DBContext.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly InfraContext _context;

        public PortfolioRepository(InfraContext context)
        {
            _context = context;
        }

        public Portfolio[] GetPortfolios()
        {
            return _context
                .Portfolios
                .AsNoTracking()
                .ToArray();
        }

        public Portfolio GetPortfolio(Guid id)
        {
            return _context
                .Portfolios
                .AsNoTracking()
                .Where(p => id.Equals(p.Id))
                .FirstOrDefault();
        }

        public void Add(Portfolio portfolio)
        {
            _context.Add(portfolio);
            _context.SaveChanges();
        }

        public bool CheckNameExists(string name)
        {
            return _context
                .Portfolios
                .AsNoTracking()
                .Any(p => name.Equals(p.Name));
        }
    }
}
