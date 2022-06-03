using AdvancedWebDev_Lab3.DataAccess.Models;

namespace AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces
{
    public interface ICastRepo
    {
        Task<IEnumerable<Cast>> GetAllCastAsync();
        Task<Cast> GetCastByIdAsync(int id);
    }
}