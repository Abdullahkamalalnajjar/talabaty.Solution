﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using talabatyyyy.Core.Entities;

namespace talabatyyyy.Core.Specification
{
    public interface ISpecification<T> where T : BaseEntities
    {
        public Expression<Func<T,bool>> Criteria { get; set; }
        public List<Expression<Func<T,object>>> Includes { get; set; }
        public Expression<Func<T,object>> OrderBy{ get; set;}
        public Expression<Func<T,object>> OrderByDescending { get; set;}
        public int Take { get; set; }   
        public int Skip { get; set; }
        public bool IsPaginatedEnable { get; set; }
    }
}
