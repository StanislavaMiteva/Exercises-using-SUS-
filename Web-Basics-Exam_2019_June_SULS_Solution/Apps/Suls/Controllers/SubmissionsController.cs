﻿using Suls.Services;
using Suls.ViewModels.Problems;
using Suls.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class SubmissionsController: Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }
        
        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
                        
            var model = new ViewProblemCreateSubmissionPageModel
            {
                Name = this.problemsService.GetNameById(id),
                ProblemId = id,
            };

            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(AddSubmissionInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Code) || input.Code.Length < 30 || input.Code.Length > 800)
            {
                return this.Error("Code should be between 30 and 800 characters long.");
            }

            var userId = this.GetUserId();            
            this.submissionsService.Add(input, userId);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            this.submissionsService.Delete(id);
            return this.Redirect("/");
        }
    }
}
