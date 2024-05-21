using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProniaCrud.Core.Models;

namespace TaskProniaCrud.Business.Services.Abstracts
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(Category category);
        void DeleteCategory(int id);
        void UpdateCategory(int id, Category newCategory);
        Category GetCategory(Func<Category, bool>? predicate=null);
        List<Category> GetAllCategories(Func<Category,bool>?predicate=null);
    }
}
