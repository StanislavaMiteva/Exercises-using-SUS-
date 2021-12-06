using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCommit(AddCommitInputModel input, string creatorId)
        {
            var commit = new Commit
            {
                Description=input.Description,
                RepositoryId=input.Id,
                CreatedOn=DateTime.UtcNow,
                CreatorId=creatorId,
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }

        public IEnumerable<ViewCommitModel> AllCommits(string userId)
        {
            return this.db.Commits
                .Where(x => x.CreatorId == userId)
                .Select(x => new ViewCommitModel
                {
                    RepositoryName = x.Repository.Name,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn,
                    Id = x.Id
                })
                .ToList();
        }

        public void Delete(string commitId)
        {
            var commitToDelete = this.db.Commits
                .Find(commitId);

            this.db.Commits.Remove(commitToDelete);
            this.db.SaveChanges();
        }

        public string GetCreatorId(string id)
        {
            return this.db.Commits
                .Find(id)
                .CreatorId;
        }
    }
}
