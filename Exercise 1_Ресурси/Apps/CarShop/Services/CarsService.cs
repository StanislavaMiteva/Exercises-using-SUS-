using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;

        public CarsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddCar(AddCarInputModel input)
        {
            var car=new Car
            { 
                Model=input.Model,
                Year=input.Year,
                PictureUrl=input.Image,
                PlateNumber=input.PlateNumber,
                OwnerId=input.OwnerId,
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public ICollection<ViewCarModel> AllCars()
        {
            throw new NotImplementedException();
        }
    }
}
