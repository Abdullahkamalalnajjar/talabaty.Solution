using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talabatyyyy.Core.Entities;
using talabatyyyy.Core.Repository;
using talabatyyyy.Core.Specification;

namespace talabatyyy.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntities
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #region Static
        public async Task<T> GetByIdAsync(int id)
        {
           return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetProductsWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetProductWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        #endregion

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvalutor<T>.GetQuery(dbContext.Set<T>() , specification);
        }

    }
}
