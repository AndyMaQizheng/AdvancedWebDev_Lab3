using Newtonsoft.Json;

namespace AdvancedWebDev_Lab3.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string? ImdbId { get; set; }
        public double? Popularity { get; set; }
        public double? Budget { get; set; }
        public double? Revenue { get; set; }
        public string? Title { get; set; }
        public string? Homepage { get; set; }
        public string? Tagline { get; set; }
        [JsonProperty("short_summary")]
        public string? ShortSummary { get; set; }
        public int? Runtime { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? VoteCount { get; set; }
        public double? VoteAverage { get; set; }
        [JsonProperty("release_year")]
        public string? ReleaseYear { get; set; }
        public double? BudgetAdj { get; set; }
        public double? RevenueAdj { get; set; }
        public double Relevance { get; set; }

        public virtual List<string>? Cast { get; set; }
        public virtual List<string>? Directors { get; set; }
        public virtual List<string>? Genres { get; set; }
        public virtual List<string>? Keywords { get; set; }
        public virtual List<string>? Productioncompanies { get; set; }
    }
}
