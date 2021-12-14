using Suls.Data;
using Suls.ViewModels.Submissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.ViewModels.Problems
{
    public class ViewProblemDetailsModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public virtual ICollection<ViewSubmissionModel> Submissions { get; set; }
    }
}
