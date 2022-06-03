using AdvancedWebDev_Lab3.DataAccess.Models;

namespace AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces
{
    public interface IDirectorRepo
    {
        Task<IEnumerable<Director>> GetAllDirectorsAsync();
        Task<Director> GetDirectorByIdAsync(int id);
    }
}