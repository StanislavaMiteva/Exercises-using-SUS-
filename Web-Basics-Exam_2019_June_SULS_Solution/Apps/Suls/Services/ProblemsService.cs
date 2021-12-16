using Suls.Data;
using Suls.ViewModels.Problems;
using Suls.ViewModels.Submissions;

using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<ViewProblemHomePageModel> GetAll()
        {
            return this.db.Problems
                .Select(x=> new ViewProblemHomePageModel
                {
                    Id=x.Id,
                    Name=x.Name,
                    Count=x.Submissions.Count(),
                })
                .ToList();
        }

        public string GetNameById(string id)
        {
            return this.db.Problems
                .FirstOrDefault(x=> x.Id==id)?
                .Name;
        }
                
        public ViewProblemDetailsModel GetProblemDetailsById(string problemId)
        {
            return this.db.Problems
                .Where(x => x.Id == problemId)
                .Select(x => new ViewProblemDetailsModel 
                {
                    Name=x.Name,
                    Submissions=x.Submissions
                    .Select(x => new ViewSubmissionModel
                    {
                        Id = x.Id,
                        AchievedResult = x.AchievedResult,
                        CreatedOn = x.CreatedOn,
                        Username = x.User.Username,
                        ProblemPoints = x.Problem.Points,
                    })
                    .ToList()
                })
                .FirstOrDefault();      
        }
    }
}
