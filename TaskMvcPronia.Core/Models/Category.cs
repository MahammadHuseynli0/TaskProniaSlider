using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMvcPronia.Core.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Product { get; set; }
    }
}
