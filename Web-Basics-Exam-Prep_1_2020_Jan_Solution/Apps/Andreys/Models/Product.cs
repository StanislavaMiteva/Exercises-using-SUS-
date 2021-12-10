using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Andreys.Models
{
    public class Product
    {
        public Product()
        {
            this.UsersProducts = new HashSet<UserProduct>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public Gender Gender { get; set; }

        public virtual ICollection<UserProduct> UsersProducts { get; set; }
    }
}