
using TaskMvcPronia.Core.Models;
using TaskMvcPronia.Core.RepositoryAbstract;
using TaskMvcPronia.Data.DAL;

namespace TaskMvcPronia.Data.RepositoryConcretes
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
