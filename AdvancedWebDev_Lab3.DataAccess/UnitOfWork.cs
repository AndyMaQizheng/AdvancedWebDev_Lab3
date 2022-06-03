using AdvancedWebDev_Lab3.DataAccess.Interfaces;
using AdvancedWebDev_Lab3.DataAccess.Repos;
using AdvancedWebDev_Lab3.DataAccess.Repos.Interfaces;

namespace AdvancedWebDev_Lab3.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdvancedWebDev_MoviesContext dbContext;

        public UnitOfWork(AdvancedWebDev_MoviesContext dbContext)
        {
            this.dbContext = dbContext;

            CastRepo = new CastRepo(dbContext);
            DirectorRepo = new DirectorRepo(dbContext);
            GenreRepo = new GenreRepo(dbContext);
            KeywordRepo = new KeywordRepo(dbContext);
            Movies = new MovieRepo(dbContext);
            ProdCompanyRepo = new ProdCompanyRepo(dbContext);
        }

        public ICastRepo CastRepo { get; private set; }

        public IDirectorRepo DirectorRepo { get; private set; }

        public IGenreRepo GenreRepo { get; private set; }

        public IKeywordRepo KeywordRepo { get; private set; }

        public IMovieRepo Movies { get; private set; }

        public IProdCompanyRepo ProdCompanyRepo { get; private set; }

        public void Dispose()
        {
            //dbContext.Dispose();
        }
    }
}
