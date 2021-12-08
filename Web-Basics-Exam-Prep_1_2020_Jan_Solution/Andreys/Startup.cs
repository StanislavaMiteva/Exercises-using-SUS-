namespace Andreys.App
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using Data;

    using SIS.MvcFramework;
    using SIS.HTTP;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> serverRoutingTable)
        {
            //using (var db = new AndreysDbContext())
            //{
            //    db.Database.EnsureCreated();
            //}
            new AndreysDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
        }
    }
}
