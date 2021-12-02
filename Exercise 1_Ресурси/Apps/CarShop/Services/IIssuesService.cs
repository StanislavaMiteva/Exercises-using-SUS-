using CarShop.ViewModels.Issues;

namespace CarShop.Services
{
    public interface IIssuesService
    {
        CarWithIssuesViewModel AllIssuesPerCar(string carId);

        void AddIssue(AddIssueInputModel input);

        void Fix(string issueId);

        void Delete(string issueId);
    }
}
