namespace Andreys.App
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using Data;

    using SUS.HTTP;
    using SUS.MvcFramework;
    using Andreys.Services;

    public class Startup : IMvcApplication
    {    
        public void Configure(List<Route> routeTable)
        {
            new AndreysDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
        }
    }
}
