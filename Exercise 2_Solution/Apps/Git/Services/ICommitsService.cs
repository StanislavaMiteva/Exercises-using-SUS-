using Git.ViewModels.Commits;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitsService
    {
        void AddCommit(AddCommitInputModel input, string creatorId);

        IEnumerable<ViewCommitModel> AllCommits(string userId);

        string GetCreatorId(string id);

        void Delete(string commitId);
    }
}
