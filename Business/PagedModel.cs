using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PagedModel<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public T Data { get; set; }

        public PagedModel(T data, int totalRecords, int pageNumber = 1, int pageSize = 100)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalRecords = totalRecords;
            this.TotalPages = (totalRecords / PageSize) + (totalRecords % PageSize > 0 ? 1 : 0);
            this.Data = data;
        }
    }
}
