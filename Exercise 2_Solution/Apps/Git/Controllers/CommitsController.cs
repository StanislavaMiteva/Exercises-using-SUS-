using Git.Services;
using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController: Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var repository = new ViewRepositoryModel
            {
                Id = id,
                Name=this.repositoriesService.GetRepositoryName(id),
            };

            return this.View(repository);
        }

        [HttpPost]
        public HttpResponse Create(AddCommitInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Description) || input.Description.Length < 5)
            {
                return this.Error("Description should be minimum 5 characters long.");
            }

            var creatorId = this.GetUserId();

            this.commitsService.AddCommit(input, creatorId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var commitsByUser = this.commitsService.AllCommits(userId);
            
            return this.View(commitsByUser);
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            var userId = this.GetUserId();
            var creatorId = this.commitsService.GetCreatorId(id);

            if (userId!=creatorId)
            {
                return this.Error("Not authorized!");
            }
            
            this.commitsService.Delete(id);

            return this.Redirect("/Commits/All");
        }
    }
}
