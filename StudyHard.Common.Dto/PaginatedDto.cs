using System.Collections.Generic;

namespace StudyHard.Common.Dto
{
    public class PaginatedDto<T>
    {
        public List<T> PaginatedList { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
