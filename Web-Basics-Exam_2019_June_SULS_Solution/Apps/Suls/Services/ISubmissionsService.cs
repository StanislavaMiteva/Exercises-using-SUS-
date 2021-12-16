using Suls.ViewModels.Submissions;

namespace Suls.Services
{
    public interface ISubmissionsService
    {
        void Add(AddSubmissionInputModel input, string creatorId);

        public void Delete(string submissionId);
    }
}
