using Domain.Entity;
using System;

namespace Domain.Repositories
{
    public interface IPortfolioRepository
    {
        void Add(Portfolio portfolio);
        bool CheckNameExists(string name);
        Portfolio GetPortfolio(Guid id);
        Portfolio[] GetPortfolios();
    }
}
