using AdvancedWebDev_Lab3.DataAccess.Models;

namespace AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces
{
    public interface IProdCompanyRepo
    {
        /// <summary>
        /// Get all production companies.
        /// </summary>
        Task<IEnumerable<ProductionCompany>> GetAllProductionCompaniesAsync();
    }
}