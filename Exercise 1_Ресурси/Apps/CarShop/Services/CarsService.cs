using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Year=int.Parse(input.Year),
                PictureUrl=input.Image,
                PlateNumber=input.PlateNumber,
                OwnerId=input.OwnerId,
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public ICollection<ViewCarModel> AllCarsForClient(string userId)
        {
            return this.db.Cars
                .Where(x=> x.OwnerId==userId)
                .Select(x=> new ViewCarModel
                {
                    Id=x.Id,
                    Image=x.PictureUrl,
                    Year=x.Year,
                    Model=x.Model,
                    PlateNumber=x.PlateNumber,
                    Issues=x.Issues.Count(),
                    FixedIssues=x.Issues.Where(x=> x.IsFixed==true).Count(),
                })
                .ToList();
        }

        public ICollection<ViewCarModel> AllCarsWithIssues()
        {
            var cars = this.db.Cars
                .Select(x => new ViewCarModel
                {
                    Id = x.Id,
                    Image = x.PictureUrl,
                    Year = x.Year,
                    Model = x.Model,
                    PlateNumber = x.PlateNumber,
                    Issues = x.Issues.Count(),
                    FixedIssues = x.Issues.Where(x => x.IsFixed == true).Count(),
                })                
                .ToList()
                .Where(x => x.RemainingIssues > 0)
                .ToList();

            return cars;
        }
    }
}
