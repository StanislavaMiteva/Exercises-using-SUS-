using CarShop.Services;
using CarShop.ViewModels.Issues;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Controllers
{
    public class IssuesController: Controller
    {
        private readonly IIssuesService issuesService;

        public IssuesController(IIssuesService issuesService)
        {
            this.issuesService = issuesService;
        }

        public HttpResponse CarIssues(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            var issuesPerCar = this.issuesService.All(carId);

            return this.View(issuesPerCar);
        }

        public HttpResponse Add(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            return this.View(carId);
        }

        [HttpPost]
        public HttpResponse Add(AddIssueInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            if (string.IsNullOrWhiteSpace(input.Description) || input.Description.Length<5)
            {
                return this.Error("Description should be minimum 5 characters long.");
            }
            
            this.issuesService.Add(input);

            return this.Redirect($"/Issues/CarIssues?carId={input.CarId}");
        }
    }
}
