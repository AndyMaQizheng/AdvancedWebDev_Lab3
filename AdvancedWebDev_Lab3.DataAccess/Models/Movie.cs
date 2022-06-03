namespace AdvancedWebDev_Lab3.DataAccess.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Genres = new HashSet<Genre>();
            Keywords = new HashSet<Keyword>();
            Directors = new HashSet<Person>();
            Cast = new HashSet<Person>();
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

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
        public virtual ICollection<Person> Directors { get; set; }
        public virtual ICollection<Person> Cast { get; set; }
        public virtual ICollection<ProductionCompany> Productioncompanies { get; set; }
    }
}
