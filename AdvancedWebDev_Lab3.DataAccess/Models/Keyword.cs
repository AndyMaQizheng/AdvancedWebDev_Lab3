namespace AdvancedWebDev_Lab3.DataAccess.Models
{
    public partial class Keyword
    {
        public Keyword()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
