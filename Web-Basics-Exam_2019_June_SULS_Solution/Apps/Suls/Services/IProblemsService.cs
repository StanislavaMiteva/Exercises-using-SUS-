using Suls.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public interface IProblemsService
    {
        void Add(AddProblemInputModel input);

        IEnumerable<ViewProblemHomePageModel> GetAll();

        string GetNameById(string id);

        int GetPointsById(string id);
    }
}
