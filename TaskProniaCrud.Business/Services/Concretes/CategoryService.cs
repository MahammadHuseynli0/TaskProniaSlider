using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProniaCrud.Business.Exceptions;
using TaskProniaCrud.Business.Services.Abstracts;
using TaskProniaCrud.Core.Models;
using TaskProniaCrud.Core.RepositoryAbstarcts;

namespace TaskProniaCrud.Business.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task AddCategoryAsync(Category category)
        {  
            if(!_categoryRepository.GetAll().Any(x=>x.Name == category.Name)) 
            {
                await _categoryRepository.AddAsync(category);
                await _categoryRepository.CommitAsync();
            }
            else
            {
                throw new DuplicateException("Category adi eyni ola bilmez");
            }
            
      
        }

        public void DeleteCategory(int id)
        {
            Category existcategory = _categoryRepository.Get(x => x.Id == id);
            if (existcategory == null) { throw new EntityNotFoundException("Silinecek bele bir category yoxdur"); }
            _categoryRepository.Delete(existcategory);
            _categoryRepository.Commit();
        }

        public List<Category> GetAllCategories(Func<Category, bool>? predicate = null)
        {
            return _categoryRepository.GetAll(predicate);
        }

        public Category GetCategory(Func<Category, bool>? predicate = null)
        {
            return _categoryRepository.Get(predicate);
        }

        public void UpdateCategory(int id, Category newCategory)
        {
            Category category = _categoryRepository.Get(x=>x.Id == id);
            if (category == null) { throw new EntityNotFoundException("Bele bir category yoxdur");}
            if (!_categoryRepository.GetAll().Any(x=> x.Name==newCategory.Name && x.Id!= category.Id)) 
            {
                category.Name = newCategory.Name;
            }
            else
            {
                throw new DuplicateException("Eyni adli category daxil ede bilmezsiniz");
            }
            _categoryRepository.Commit();
        }
    }
}
