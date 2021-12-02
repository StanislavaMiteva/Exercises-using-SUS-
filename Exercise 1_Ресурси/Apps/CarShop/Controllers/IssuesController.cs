using CarShop.Services;
using CarShop.ViewModels.Issues;
using SUS.HTTP;
using SUS.MvcFramework;

namespace CarShop.Controllers
{
    public class IssuesController: Controller
    {
        private readonly IIssuesService issuesService;
        private readonly IUsersService usersService;

        public IssuesController(IIssuesService issuesService, IUsersService usersService)
        {
            this.issuesService = issuesService;
            this.usersService = usersService;
        }

        public HttpResponse CarIssues(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            var issuesPerCar = this.issuesService.AllIssuesPerCar(carId);

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
            
            this.issuesService.AddIssue(input);

            return this.Redirect($"/Issues/CarIssues?carId={input.CarId}");
        }

        public HttpResponse Fix(string issueId, string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            var isMechanic = this.usersService.IsUserMechanic(this.GetUserId());

            if (!isMechanic)
            {
                return this.Error("Not authorized!");
            }

            this.issuesService.Fix(issueId);

            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }

        public HttpResponse Delete(string issueId, string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.issuesService.Delete(issueId);
            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
