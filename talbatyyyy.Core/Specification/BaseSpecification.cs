using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using talabatyyyy.Core.Entities;

namespace talabatyyyy.Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntities
    {
        public Expression<Func<T, bool>> Criteria { get ; set ; }
        public List<Expression<Func<T, object>>> Includes { get ; set ; } = new List<Expression<Func<T, object>>> ();
        public Expression<Func<T, object>> OrderBy { get ; set ; }
        public Expression<Func<T, object>> OrderByDescending { get; set ; }
        public int Take { get ; set ; }
        public int Skip { get ; set ; }
        public bool IsPaginatedEnable { get ; set; }

        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> Criteria)
        {
            this.Criteria = Criteria;
        }

        public void AddOrderBy(Expression<Func<T, object>> orderBy)
        {
            this.OrderBy = orderBy;
        }
        public void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
        {
            this.OrderByDescending = orderByDescending;
        }

        public void AddPagination(int skip , int take)
        {
            IsPaginatedEnable = true;
            this.Skip = skip;
            this.Take = take;
        }
    }
}
