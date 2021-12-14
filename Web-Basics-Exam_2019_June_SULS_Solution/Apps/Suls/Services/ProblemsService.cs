using Suls.Data;
using Suls.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(AddProblemInputModel input)
        {
            var problem=new Problem
            {
                Name=input.Name,
                Points=int.Parse(input.Points),
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public IEnumerable<ViewProblemModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
