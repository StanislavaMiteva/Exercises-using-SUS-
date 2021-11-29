using CarShop.Services;
using CarShop.ViewModels.Cars;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarShop.Controllers
{
    public class CarsController: Controller
    {
        private readonly ICarsService carsService;

        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }
        
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
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
        public HttpResponse Add(AddCarInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Model.Length<5 || input.Model.Length>20 || string.IsNullOrWhiteSpace(input.Model))
            {
                return this.Error("Model should be between 5 and 20 characters long.");
            }

            if (string.IsNullOrWhiteSpace(input.Image))
            {
                return this.Error("Image url is required.");
            }

            bool plateNumberIsValid = Regex.IsMatch(input.PlateNumber, @"^[A-Z]{2}[0-9]{4}[A-Z]{2}$");

            if (string.IsNullOrWhiteSpace(input.PlateNumber) || !plateNumberIsValid)
            {
                return this.Error("Not a valid Plate number (2 Capital English letters, followed by 4 digits, followed by 2 Capital English letters).");
            }

            var ownerId = this.GetUserId();
            input.OwnerId = ownerId;

            this.carsService.AddCar(input);

            return this.Redirect("/Cars/All");
        }
    }
}
