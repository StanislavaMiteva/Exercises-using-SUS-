using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Services
{
    public interface IIssuesService
    {
        IssuesPerCarViewModel All(string carId);

        void Add(AddIssueInputModel input);
    }
}
