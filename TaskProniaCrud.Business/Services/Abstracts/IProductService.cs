using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProniaCrud.Core.Models;

namespace TaskProniaCrud.Business.Services.Abstracts
{
    public interface IProductService
    {

        Task AddProductAsync(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(int id, Product newProduct);
        Product GetProduct(Func<Product, bool>? predicate = null);
        List<Product> GetAllProducts(Func<Product, bool>? predicate = null);

    }
}
