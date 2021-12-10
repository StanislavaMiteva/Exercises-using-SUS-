using Andreys.Data;
using Andreys.Models;
using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void Add(AddProductInputModel input)
        {
            var product = new Product
            {
                Name = input.Name,
                Description = input.Description,
                ImageUrl = input.ImageUrl,
                Category = Enum.Parse<Category>(input.Category),
                Gender = Enum.Parse<Gender>(input.Gender),
                Price = decimal.Parse(input.Price),
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public IEnumerable<ViewProductHomePageModel> All()
        {
            return this.db.Products
                .Select(x => new ViewProductHomePageModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                })
                .ToList();
        }

        public ViewProductDetailsModel GetById(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
