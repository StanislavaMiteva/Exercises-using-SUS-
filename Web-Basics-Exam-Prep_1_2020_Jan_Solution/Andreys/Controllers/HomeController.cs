namespace Andreys.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            //if (this.IsUserLoggedIn())
            //{
            //    return this.Redirect("/Products/All");
            //}

            return this.View();
        }
    }
}
