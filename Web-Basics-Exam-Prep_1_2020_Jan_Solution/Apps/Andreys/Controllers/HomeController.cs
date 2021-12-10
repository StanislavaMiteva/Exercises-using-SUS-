namespace Andreys.App.Controllers
{
    using Andreys.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

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
            if (this.IsUserSignedIn())
            {
                return this.Home();
            }

            return this.View();
        }

        public HttpResponse Home()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Index();
            }

            var model = this.productsService.All();

            return this.View(model);
        }
    }
}
