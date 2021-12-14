using Suls.Services;
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
                return this.Redirect("/Home/IndexLoggedIn");
            }

            return this.View();
        }

        public HttpResponse IndexLoggedIn()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var problems = this.problemsService.GetAll();
            return this.View(problems);
        }
    }
}
