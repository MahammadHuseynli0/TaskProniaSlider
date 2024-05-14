using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TaskMvcPronia.Core.Models
{
    public class Product:BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public List<Category> Category { get; set; }

        public string ImageURL { get; set; } = null!;
        [NotMapped]
        public IFormFile ImageFile { get; set; } = null!;
    }
}
