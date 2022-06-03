using AdvancedWebDev_Lab3.DataAccess.Models;

namespace AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces
{
    public interface IProdCompanyRepo
    {
        Task<IEnumerable<ProductionCompany>> GetAllProductionCompaniesAsync();
        Task<ProductionCompany> GetProductionCompanyByIdAsync(int id);
    }
}