using Suls.ViewModels.Submissions;

using System.Collections.Generic;

namespace Suls.Services
{
    public interface ISubmissionsService
    {
        void Add(AddSubmissionInputModel input, string creatorId, int points);

        IEnumerable<ViewSubmissionModel> AllByProblemId(string problemId);

        public void Delete(string submissionId);
    }
}
