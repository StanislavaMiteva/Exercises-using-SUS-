using Suls.ViewModels.Problems;
using System.Collections.Generic;

namespace Suls.Services
{
    public interface IProblemsService
    {
        void Add(AddProblemInputModel input);

        IEnumerable<ViewProblemHomePageModel> GetAll();

        string GetNameById(string id);

        ViewProblemDetailsModel GetProblemDetailsById(string problemId);
    }
}
