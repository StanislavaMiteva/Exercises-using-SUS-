﻿namespace BattleCards
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using BattleCards.Data;
    using BattleCards.Services;

    using SUS.HTTP;
    using SUS.MvcFramework;

    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICardsService, CardsService>();
        }
    }
}
