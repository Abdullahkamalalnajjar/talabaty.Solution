using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talabatyyyy.Core.ParamOfQuery
{
    public class ProductParamQuery
    {
        //   string? sort, int? brandid, int? typeid, int pageSize, int pageIndex
        public const int  MaxPageSize= 10;
        private int pageSize = 5;
        public string? Sort {  get; set; }
        public int? BrandId { get; set; }
        public int ? TypeId { get; set; }
        public int PageSize { 
            get {
                return pageSize;
            }
            set {
                pageSize= value>MaxPageSize? MaxPageSize:value;
            }
        }
        public int PageIndex { get; set; } = 1;
    }
}
