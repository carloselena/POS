namespace POS.Core.Application.Common.DTOs
{
    public class PaginationFilter
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
    }
}
