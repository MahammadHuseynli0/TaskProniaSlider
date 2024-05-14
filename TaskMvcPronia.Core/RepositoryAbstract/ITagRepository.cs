using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskMvcPronia.Core.RepositoryAbstract.IGenrericrepository;
using TaskMvcPronia.Core.Models;

namespace TaskMvcPronia.Core.RepositoryAbstract
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
    }
}
