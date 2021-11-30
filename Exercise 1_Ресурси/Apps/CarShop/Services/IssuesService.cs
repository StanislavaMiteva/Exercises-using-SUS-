using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext db;

        public IssuesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(AddIssueInputModel input)
        {
            var issue = new Issue
            {
                CarId=input.CarId,
                Description=input.Description,
                IsFixed=false,
            };

            this.db.Issues.Add(issue);
            this.db.SaveChanges();
        }

        public IssuesPerCarViewModel All(string carId)
        {
            var car = this.db.Cars
                .FirstOrDefault(x => x.Id == carId);

            var issues = new IssuesPerCarViewModel
            {
                CarId = car.Id,
                Model = car.Model,
                Year = car.Year,
                IssuesPerCar = car.Issues,
            };

            return issues;   

        }
    }
}
