using Suls.Services;
using Suls.ViewModels.Problems;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Controllers
{
    public class ProblemsController: Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();

        }

        [HttpPost]
        public HttpResponse Create(AddProblemInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name) || input.Name.Length < 5 || input.Name.Length > 20)
            {
                return this.Error("Name should be between 5 and 20 characters long.");
            }

            if (!int.TryParse(input.Points,out _) || int.Parse(input.Points) < 50 || int.Parse(input.Points) > 300)
            {
                return this.Error("Points should be an integer between 50 and 300.");
            }

            this.problemsService.Add(input);
            return this.Redirect("/");
        }

    }
}
