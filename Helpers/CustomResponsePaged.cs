using Microsoft.AspNetCore.Http;

namespace BMP280API.Helpers
{
    public class CustomResponsePaged<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }
        
        public T Result { get; set; }

        public static CustomResponsePaged<PaginatedList<T>> BuildFromPaginatedList(PaginatedList<T> paginatedList)
        {
            return new CustomResponsePaged<PaginatedList<T>>
            {
                Result = paginatedList,
                PageIndex = paginatedList.PageIndex,
                TotalPages = paginatedList.TotalPages,
                HasNextPage = paginatedList.HasNextPage,
                HasPreviousPage = paginatedList.HasPreviousPage
            };
        }
    }
}