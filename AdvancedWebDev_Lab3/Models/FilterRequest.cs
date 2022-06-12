namespace AdvancedWebDev_Lab3.Models
{
    public class FilterRequest
    {
        public Dictionary<string, List<string>> Filters { get; set; } = new Dictionary<string, List<string>>();

        public int NumOfResults { get; set; } = 20;
    }
}
