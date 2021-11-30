using CarShop.Services;
using CarShop.ViewModels.Cars;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CarShop.Controllers
{
    public class CarsController: Controller
    {
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;

        public CarsController(ICarsService carsService, IUsersService usersService)
        {
            this.carsService = carsService;
            this.usersService = usersService;
        }
        
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var isMechanic = this.usersService.IsUserMechanic(userId);

            var cars = new List<ViewCarModel>();

            if (isMechanic)
            {
                var carsWithIssues = this.carsService.AllCarsWithIssues();
                cars.AddRange(carsWithIssues);
            }
            else
            {
                var carsForClient = this.carsService.AllCarsForClient(userId);
                cars.AddRange(carsForClient);
            }            

            return this.View(cars);
        }


        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var isMechanic = this.usersService.IsUserMechanic(this.GetUserId());

            if (isMechanic)
            {
                return this.Error("Not authorized!");
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

            var isMechanic = this.usersService.IsUserMechanic(this.GetUserId());

            if (isMechanic)
            {
                return this.Error("Not authorized!");
            }

            if (input.Model.Length<5 || input.Model.Length>20 || string.IsNullOrWhiteSpace(input.Model))
            {
                return this.Error("Model should be between 5 and 20 characters long.");
            }

            if (!int.TryParse(input.Year,out _) || int.Parse(input.Year)<1900 || int.Parse(input.Year)> DateTime.UtcNow.Year)
            {
                return this.Error("Year should be an integer between 1900 and current year.");
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
