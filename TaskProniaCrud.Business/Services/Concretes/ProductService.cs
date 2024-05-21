using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProniaCrud.Business.Exceptions;
using TaskProniaCrud.Business.Services.Abstracts;
using TaskProniaCrud.Core.Models;
using TaskProniaCrud.Core.RepositoryAbstarcts;
using TaskProniaCrud.Data.RepositoryConcretes;

namespace TaskProniaCrud.Business.Services.Concretes
{
    public class ProductService : IProductService
    {
        IProductRepositroy _productRepository;

        public ProductService(IProductRepositroy productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProductAsync(Product product)
        {

            await _productRepository.AddAsync(product);
            await _productRepository.CommitAsync();

        }

     

        public void DeleteProduct(int id)
        {
            Product product = _productRepository.Get(x => x.Id == id);

            if (product == null) throw new NullReferenceException();

            _productRepository.Delete(product);
            _productRepository.Commit();
        }

        public List<Product> GetAllProducts(Func<Product, bool>? predicate = null)
        {
            return _productRepository.GetAll(predicate);
        }

        public Product GetProduct(Func<Product, bool>? predicate = null)
        {
            return _productRepository.Get(predicate);
        }

        public void UpdateProduct(int id, Product newProduct)
        {
            Product product = _productRepository.Get(x => x.Id == id);

            if (product == null) throw new NullReferenceException();


            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            product.ImageURL = newProduct.ImageURL;
            product.Description = newProduct.Description;
            product.CategoryId = newProduct.CategoryId;
            product.ImageFile = newProduct.ImageFile;
            _productRepository.Commit();
        }
    }
}
