namespace AdvancedWebDev_Lab3.DataAccess.Models
{
    public class FilterResult
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public Dictionary<int, double> Relevances { get; set; } = new Dictionary<int, double>();
    }
}
