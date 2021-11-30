using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.ViewModels.Issues
{
    public class IssuesPerCarViewModel
    {
        public string CarId { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public ICollection<Issue> IssuesPerCar { get; set; }
    }
}
