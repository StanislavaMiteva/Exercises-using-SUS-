using Suls.ViewModels.Submissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public interface ISubmissionsService
    {
        void Add(AddSubmissionInputModel input, string creatorId, int points);

        IEnumerable<ViewSubmissionModel> All();
    }
}
