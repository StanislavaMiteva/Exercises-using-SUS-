using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    public interface IProductsService
    {
        void Add(AddProductInputModel input);

        IEnumerable<ViewProductHomePageModel> All();

        ViewProductDetailsModel GetById(int productId);

        void Delete(int id);
    }
}
