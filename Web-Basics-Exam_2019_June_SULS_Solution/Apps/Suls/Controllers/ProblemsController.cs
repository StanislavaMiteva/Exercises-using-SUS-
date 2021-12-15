﻿using Suls.Services;
using Suls.ViewModels.Problems;

using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class ProblemsController: Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public ProblemsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
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

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = new ViewProblemDetailsModel
            {
                Id = id,
                Name = this.problemsService.GetNameById(id),
                Submissions = this.submissionsService.AllByProblemId(id),
            };
            return this.View(model);
        }
    }
}
