using Andreys.Models;
using Andreys.Services;
using Andreys.ViewModels.Products;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Controllers
{
    class ProductsController: Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddProductInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name) || input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Name should be between 4 and 20 characters long.");
            }

            if (input.Description.Length > 10)
            {
                return this.Error("Description should be maximum 10 characters long.");
            }

            if (!decimal.TryParse(input.Price,out _) || decimal.Parse(input.Price)<=0)
            {
                return this.Error("Price should be a positive decimal number");
            }

            if (!Enum.TryParse<Category>(input.Category,true, out _))
            {
                return this.Error("Category is required and should be one of the dropdown menu");
            }

            if (!Enum.TryParse<Gender>(input.Gender, true, out _))
            {
                return this.Error("Gender is required and should be one of the dropdown menu");
            }

            this.productsService.Add(input);
            return this.Redirect("/Home/Home");
        }
        
        public HttpResponse Details(int id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            ViewProductDetailsModel model = this.productsService.GetById(id);
            return this.View(model);
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            this.productsService.Delete(id);
            return this.Redirect("/");
        }
    }
}
