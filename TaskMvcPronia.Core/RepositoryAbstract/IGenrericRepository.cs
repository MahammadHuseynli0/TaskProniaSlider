using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMvcPronia.Core.Models;

namespace TaskMvcPronia.Core.RepositoryAbstract
{
    public interface IGenrericrepository
    {
        public interface IGenericRepository<T> where T : BaseEntity, new()
        {
            Task AddAsync(T entity);
            void Delete(T entity);
            T Get(Func<T, bool>? predicate = null);
            List<T> GetAll(Func<T, bool>? predicate = null);
            int Commit();
            Task CommitAsync();
        }
    }
}
