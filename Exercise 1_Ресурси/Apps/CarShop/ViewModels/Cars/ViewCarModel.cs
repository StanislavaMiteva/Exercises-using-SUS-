namespace CarShop.ViewModels.Cars
{
    public class ViewCarModel
    {
        public string Id { get; set; }
        
        public string Model { get; set; }

        public int Year { get; set; }

        public string Image { get; set; }

        public string PlateNumber { get; set; }

        public int Issues { get; set; }

        public int FixedIssues { get; set; }

        public int RemainingIssues => this.Issues - this.FixedIssues;
    }
}
