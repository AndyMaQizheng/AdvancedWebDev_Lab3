namespace AdvancedWebDev_Lab3.Filters
{
    public class PaginationFilter
    {
        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 50;
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 50 ? 50 : pageSize;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
