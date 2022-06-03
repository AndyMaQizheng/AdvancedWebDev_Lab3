namespace AdvancedWebDev_Lab3.DataAccess.Models
{
    public partial class Cast
    {
        public Cast()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
