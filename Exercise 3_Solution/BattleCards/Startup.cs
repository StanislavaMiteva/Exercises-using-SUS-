namespace BattleCards
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using BattleCards.Data;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using BattleCards.Services;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
        }
    }
}
