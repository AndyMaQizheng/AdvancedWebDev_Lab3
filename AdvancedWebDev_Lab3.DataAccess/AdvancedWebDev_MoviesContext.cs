using AdvancedWebDev_Lab3.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedWebDev_Lab3.DataAccess
{
    public partial class AdvancedWebDev_MoviesContext : DbContext
    {
        public AdvancedWebDev_MoviesContext()
        {
        }

        public AdvancedWebDev_MoviesContext(DbContextOptions<AdvancedWebDev_MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Keyword> Keywords { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<ProductionCompany> ProductionCompanies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:advancedwebdev.database.windows.net,1433;Initial Catalog=AdvancedWebDev_Movies;Persist Security Info=False;User ID=primaryLogin;Password=Server34Password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genres");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Budget).HasColumnName("budget");

                entity.Property(e => e.BudgetAdj).HasColumnName("budget_adj");

                entity.Property(e => e.Homepage)
                    .IsUnicode(false)
                    .HasColumnName("homepage");

                entity.Property(e => e.ImdbId)
                    .HasMaxLength(50)
                    .HasColumnName("imdb_id");

                entity.Property(e => e.OriginalTitle)
                    .IsUnicode(false)
                    .HasColumnName("original_title");

                entity.Property(e => e.Overview)
                    .IsUnicode(false)
                    .HasColumnName("overview");

                entity.Property(e => e.Popularity).HasColumnName("popularity");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.Property(e => e.ReleaseYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("release_year");

                entity.Property(e => e.Revenue).HasColumnName("revenue");

                entity.Property(e => e.RevenueAdj).HasColumnName("revenue_adj");

                entity.Property(e => e.Runtime).HasColumnName("runtime");

                entity.Property(e => e.Tagline)
                    .IsUnicode(false)
                    .HasColumnName("tagline");

                entity.Property(e => e.VoteAverage).HasColumnName("vote_average");

                entity.Property(e => e.VoteCount).HasColumnName("vote_count");

                entity.HasMany(d => d.Genres)
                    .WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "Moviesgenre",
                        l => l.HasOne<Genre>().WithMany().HasForeignKey("GenreId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_moviesgenres_Genre"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_moviesgenres_Movies"),
                        j =>
                        {
                            j.HasKey("MovieId", "GenreId");

                            j.ToTable("moviesgenres");

                            j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");

                            j.IndexerProperty<int>("GenreId").HasColumnName("genre_id");
                        });

                entity.HasMany(d => d.Keywords)
                    .WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "Movieskeyword",
                        l => l.HasOne<Keyword>().WithMany().HasForeignKey("KeywordId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_movieskeywords_Keywords"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_movieskeywords_Movies"),
                        j =>
                        {
                            j.HasKey("MovieId", "KeywordId");

                            j.ToTable("movieskeywords");

                            j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");

                            j.IndexerProperty<int>("KeywordId").HasColumnName("keyword_id");
                        });

                entity.HasMany(d => d.Productioncompanies)
                    .WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "Moviesproductioncompany",
                        l => l.HasOne<ProductionCompany>().WithMany().HasForeignKey("ProductioncompanyId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_moviesproductioncompanies_ProductionCompanies"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_moviesproductioncompanies_Movies"),
                        j =>
                        {
                            j.HasKey("MovieId", "ProductioncompanyId");

                            j.ToTable("moviesproductioncompanies");

                            j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");

                            j.IndexerProperty<int>("ProductioncompanyId").HasColumnName("productioncompany_id");
                        });
            });

            modelBuilder.Entity<ProductionCompany>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
