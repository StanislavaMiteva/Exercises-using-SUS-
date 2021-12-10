namespace Andreys.App.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            if (this.IsUserSignedIn())
            {
                return this.Home();
            }

            return this.Index();
        }

        public HttpResponse Index()
        {            
            return this.View();
        }

        public HttpResponse Home()
        {
            return this.View();
        }
    }
}
