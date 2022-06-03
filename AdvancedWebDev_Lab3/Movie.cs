using System;
using System.Collections.Generic;

namespace AdvancedWebDev_Lab3
{
    public partial class Movie
    {
        public Movie()
        {
            Casts = new HashSet<Cast>();
            Directors = new HashSet<Director>();
            Genres = new HashSet<Genre>();
            Keywords = new HashSet<Keyword>();
            Productioncompanies = new HashSet<ProductionCompany>();
        }

        public int Id { get; set; }
        public string? ImdbId { get; set; }
        public double? Popularity { get; set; }
        public double? Budget { get; set; }
        public double? Revenue { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Homepage { get; set; }
        public string? Tagline { get; set; }
        public string? Overview { get; set; }
        public int? Runtime { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? VoteCount { get; set; }
        public double? VoteAverage { get; set; }
        public string? ReleaseYear { get; set; }
        public double? BudgetAdj { get; set; }
        public double? RevenueAdj { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
        public virtual ICollection<ProductionCompany> Productioncompanies { get; set; }
    }
}
