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

        public void Add(AddProductInputModel input, string creatorId)
        {
            var product = new Product
            {
                Name = input.Name,
                Description = input.Description,
                ImageUrl = input.ImageUrl,
                Category = Enum.Parse<Category>(input.Category),
                Gender = Enum.Parse<Gender>(input.Gender),
                Price = decimal.Parse(input.Price),
                CreatorId=creatorId,
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

        public void Delete(int id)
        {
            var productToDelete=this.db.Products
                .Find(id);
            this.db.Products.Remove(productToDelete);
            this.db.SaveChanges();
        }

        public ViewProductDetailsModel GetById(int productId)
        {
            return this.db.Products                
                .Select(x=> new ViewProductDetailsModel 
                {
                    Id=x.Id,
                    Name=x.Name,
                    Description=x.Description,
                    ImageUrl=x.ImageUrl,
                    Gender=x.Gender.ToString(),
                    Category=x.Category.ToString(),
                    Price=x.Price,
                })
                .FirstOrDefault(x => x.Id == productId);
        }

        public bool ProductCanBeDeleted(int productId, string userId)
        {
            var creatorId = this.db.Products
                .FirstOrDefault(x => x.Id==productId)
                .CreatorId;

            return creatorId == userId;
        }
    }
}
