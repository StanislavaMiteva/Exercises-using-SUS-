using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Andreys.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<Product>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Username { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}