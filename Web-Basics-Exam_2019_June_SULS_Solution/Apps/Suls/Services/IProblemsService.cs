using Suls.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public interface IProblemsService
    {
        void Add(AddProblemInputModel input);

        IEnumerable<ViewProblemModel> GetAll();

    }
}
