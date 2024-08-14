using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talabatyyyy.Core.Entities;
using talabatyyyy.Core.Specification;

namespace talabatyyyy.Core.Repository
{
    public interface IGenericRepository<T> where T : BaseEntities
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);

        public Task<IEnumerable<T>> GetProductsWithSpecAsync(ISpecification<T> spec);
        public Task<T> GetProductWithSpecAsync(ISpecification<T> spec);
    }
}
