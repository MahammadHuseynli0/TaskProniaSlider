
using TaskMvcPronia.Core.Models;
using TaskMvcPronia.Core.RepositoryAbstract;
using TaskMvcPronia.Data.DAL;

namespace TaskMvcPronia.Data.RepositoryConcretes
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
