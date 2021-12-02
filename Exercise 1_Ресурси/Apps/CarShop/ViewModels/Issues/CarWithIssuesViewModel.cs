using System.Collections.Generic;

namespace CarShop.ViewModels.Issues
{
    public class CarWithIssuesViewModel
    {
        public string CarId { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public ICollection<IssueViewModel> IssuesPerCar { get; set; }
    }
}
