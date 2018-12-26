using System.Collections.Generic;

namespace SmallEshop.Core.Utilities
{
    public interface IPager
    {
        int CurrentPage { get; set; }
        int FirstPage { get; set; }
        bool HasNextPage { get; set; }
        bool HasPreviousPage { get; set; }
        bool IsFirstPage { get; set; }
        bool IsLastPage { get; set; }
        int LastPage { get; set; }
        List<int> NearPages { get; set; }
        int NextPage { get; set; }
        int PageSize { get; set; }
        int PreviousPage { get; set; }
        int Skip { get; set; }
        int TotalItems { get; set; }
        int TotalPages { get; set; }
    }
}