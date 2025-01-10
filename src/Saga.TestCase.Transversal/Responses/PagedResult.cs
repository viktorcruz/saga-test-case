namespace Saga.TestCase.Transversal.Responses
{
    public class PagedResult<T>
    {
        public List<T> Results { get; set; } = new();
        public int TotalCount { get; set; }      
        public int PageSize { get; set; }        
        public int CurrentPage { get; set; }     

        public PagedResult(List<T> items, int totalCount, int currentPage, int pageSize)
        {
            Results = items;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
    }
}