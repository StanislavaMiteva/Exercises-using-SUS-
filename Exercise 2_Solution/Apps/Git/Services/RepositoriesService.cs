using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddRepository(AddRepositoryInputModel input)
        {
            var repository = new Repository
            {
                Name = input.Name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = input.RepositoryType== "Public",
                OwnerId = input.OwnerId,
            };

            this.db.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<ViewRepositoryModel> AllPublicRepositories()
        {
            return this.db.Repositories
                .Where(x => x.IsPublic == true)
                .Select(x => new ViewRepositoryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedOn = x.CreatedOn,
                    OwnerName = x.Owner.Username,
                    CommitsCount = x.Commits.Count(),
                })
                .ToList();
        }
    }
}
