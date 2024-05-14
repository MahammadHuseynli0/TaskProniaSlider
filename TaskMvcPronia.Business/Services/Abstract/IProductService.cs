using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMvcPronia.Core.Models;

namespace TaskMvcPronia.Business.Services.Abstract
{
    public interface IProductService
    {
        public interface IProductService
        {
            Task AddAsync(Product product);
            void Update(int id, Product newProduct);
            void Delete(int id);
            Product GetProduct(Func<Product, bool>? predicate = null);
            List<Product> GetAll(Func<Product, bool>? predicate = null);

        }
    }
}
