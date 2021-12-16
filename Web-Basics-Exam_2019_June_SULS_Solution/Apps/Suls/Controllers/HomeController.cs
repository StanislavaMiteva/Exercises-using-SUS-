﻿using Suls.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class HomeController: Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                var problems = this.problemsService.GetAll();
                return this.View(problems, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }            
        }
    }
}
