using AdvancedWebDev_Lab3.DataAccess.Models;
using AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvancedWebDev_Lab3.DataAccess.Repos
{
    public class ProdCompanyRepo : IProdCompanyRepo
    {
        private readonly AdvancedWebDev_MoviesContext dbContext;

        public ProdCompanyRepo(AdvancedWebDev_MoviesContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductionCompany>> GetAllProductionCompaniesAsync()
        {
            return await dbContext.ProductionCompanies.ToListAsync();
        }

        public async Task<ProductionCompany> GetProductionCompanyByIdAsync(int id)
        {
            return await dbContext.ProductionCompanies
                .Include(p => p.Movies)
                .SingleAsync(p => p.Id == id);
        }
    }
}
