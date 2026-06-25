using Microsoft.EntityFrameworkCore;

namespace MyStore.Extention
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int QueryCount { get; private set; }
        public bool HasPreviousPage => PageIndex > 1;//just get no set
        public bool HasNextPage => PageIndex < TotalPages;


        public PaginatedList(List<T> items, int count, int pageIndex , int pageSize)
        {
            PageIndex = pageIndex;
            QueryCount = count;
            TotalPages =(int) Math.Ceiling( count /(double) pageSize);

            AddRange(items); //explin it
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source , int pageIndex , int pageSize)
        {
            var count = source.Count();

            var items = await source.Skip((pageIndex - 1) * pageSize) //to show current pageIndex
                        .Take(pageSize)
                        .ToListAsync();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);

        }
    }
}
