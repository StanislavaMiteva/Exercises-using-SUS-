using CarShop.ViewModels.Cars;
using System.Collections.Generic;

namespace CarShop.Services
{
    public interface ICarsService
    {
        void AddCar(AddCarInputModel input);

        IEnumerable<ViewCarModel> AllCarsForClient(string userId);

        IEnumerable<ViewCarModel> AllCarsWithIssues();
    }
}
