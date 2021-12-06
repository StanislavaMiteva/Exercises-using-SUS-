using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        void AddRepository(AddRepositoryInputModel input);

        IEnumerable<ViewRepositoryModel> AllPublicRepositories();
    }
}
