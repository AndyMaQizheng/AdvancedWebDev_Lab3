using AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces;

namespace AdvancedWebDev_Lab3.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICastRepo CastRepo { get; }
        IDirectorRepo DirectorRepo { get; }
        IGenreRepo GenreRepo { get; }
        IKeywordRepo KeywordRepo { get; }
        IMovieRepo Movies { get; }
        IProdCompanyRepo ProdCompanyRepo { get; }
    }
}
