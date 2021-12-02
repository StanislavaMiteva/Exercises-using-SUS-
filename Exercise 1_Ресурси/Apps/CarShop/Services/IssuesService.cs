using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Issues;
using System.Linq;

namespace CarShop.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext db;

        public IssuesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddIssue(AddIssueInputModel input)
        {
            var issue = new Issue
            {
                CarId = input.CarId,
                Description = input.Description,
                IsFixed = false,
            };

            this.db.Issues.Add(issue);
            this.db.SaveChanges();
        }

        public CarWithIssuesViewModel AllIssuesPerCar(string carId)
        {
            //var car = this.db.Cars
            //    .FirstOrDefault(x => x.Id == carId);

            //var issues = new IssuesPerCarViewModel
            //{
            //    CarId = car.Id,
            //    Model = car.Model,
            //    Year = car.Year,
            //    IssuesPerCar = this.db.Issues
            //        .Where(x => x.CarId == carId)
            //        .Select(x=> new IssueViewModel
            //        {
            //            Id=x.Id,
            //            Description=x.Description,
            //            IsFixed=x.IsFixed,
            //            CarId=x.CarId,
            //        })
            //        .ToList(),
            //};

            var issuesPerCar = this.db.Cars
                .Select(x => new CarWithIssuesViewModel
                {
                    CarId = x.Id,
                    Model = x.Model,
                    Year = x.Year,
                    IssuesPerCar = x.Issues
                            .Select(x => new IssueViewModel
                            {
                                Id = x.Id,
                                Description = x.Description,
                                IsFixed = x.IsFixed,
                                CarId = x.CarId,
                            })
                            .ToList(),
                })
                .FirstOrDefault(x=> x.CarId==carId);

            return issuesPerCar;
        }

        public void Delete(string issueId)
        {
            var issueToDelete = this.db.Issues
                .Find(issueId);
            this.db.Issues.Remove(issueToDelete);
            this.db.SaveChanges();
        }

        public void Fix(string issueId)
        {
            var issueToFix = this.db.Issues
                //.Find(issueId); or:
                .FirstOrDefault(x => x.Id == issueId);
            issueToFix.IsFixed = true;
            this.db.SaveChanges();
        }
    }
}
