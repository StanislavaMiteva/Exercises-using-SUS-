using Suls.ViewModels.Submissions;

using System.Collections.Generic;

namespace Suls.ViewModels.Problems
{
    public class ViewProblemDetailsModel
    {
        public string Name { get; set; }

        public virtual IEnumerable<ViewSubmissionModel> Submissions { get; set; }
    }
}
