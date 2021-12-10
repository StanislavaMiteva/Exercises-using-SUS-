using Andreys.ViewModels.Products;
using System.Collections.Generic;

namespace Andreys.Services
{
    public interface IProductsService
    {
        void Add(AddProductInputModel input, string creatorId);

        IEnumerable<ViewProductHomePageModel> All();

        ViewProductDetailsModel GetById(int productId);

        bool ProductCanBeDeleted(int productId, string userId);

        void Delete(int id);
    }
}
