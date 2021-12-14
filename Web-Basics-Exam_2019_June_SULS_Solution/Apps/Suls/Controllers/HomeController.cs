using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class HomeController: Controller
    {
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
                return this.Redirect("/Home/Index");
            }

            
            return this.View();
        }
    }
}
