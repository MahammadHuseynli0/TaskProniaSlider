using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMvcPronia.Business.Services.Abstract;
using TaskMvcPronia.Core.Models;
using TaskMvcPronia.Core.RepositoryAbstract;

namespace TaskMvcPronia.Business.Services.Concretes
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product product)
        {
            if (!_productRepository.GetAll().Any(x => x.Name == product.Name))
            {
                await _productRepository.AddAsync(product);
                await _productRepository.CommitAsync();
            }
        }

        public void Delete(int id)
        {
            var data = _productRepository.Get(x => x.Id == id);

            if (data == null) throw new NullReferenceException();

            _productRepository.Delete(data);

        }

        public List<Product> GetAll(Func<Product, bool>? predicate = null)
        {
            return _productRepository.GetAll(predicate);
        }

        public Product GetProduct(Func<Product, bool>? predicate = null)
        {
            return _productRepository.Get(predicate);
        }

        public void Update(int id, Product newProduct)
        {
            var data = _productRepository.Get(x => x.Id == id);

            if (data == null) throw new NullReferenceException();


            if (!_productRepository.GetAll().Any(x => x.Name == newProduct.Name))
            {
                data.Name = newProduct.Name;
                data.Price = newProduct.Price;
                data.Description = newProduct.Description;
                data.ImageURL = newProduct.ImageURL;
                data.ImageFile = newProduct.ImageFile;
                data.Category = newProduct.Category;
                data.Tag = newProduct.Tag;
                data.TagId = newProduct.TagId;
            }
            _productRepository.Commit();
        }
    }
}
