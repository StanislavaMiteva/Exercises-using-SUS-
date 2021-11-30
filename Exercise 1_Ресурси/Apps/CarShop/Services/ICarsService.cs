using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Services
{
    public interface ICarsService
    {
        void AddCar(AddCarInputModel input);

        ICollection<ViewCarModel> AllCarsForClient(string userId);
        ICollection<ViewCarModel> AllCarsWithIssues();
    }
}
