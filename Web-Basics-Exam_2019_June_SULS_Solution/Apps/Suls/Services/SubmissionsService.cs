using Suls.Data;
using Suls.ViewModels.Submissions;

using System;
using System.Linq;

namespace Suls.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionsService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public void Add(AddSubmissionInputModel input, string userId)
        {            
            var points = this.db.Problems
                .FirstOrDefault(x => x.Id == input.ProblemId)
                .Points;
            int achievedResult = this.random.Next(0, points+1);

            var submission =new Submission 
            {
                Code=input.Code,
                CreatedOn=DateTime.UtcNow,
                UserId=userId,
                ProblemId=input.ProblemId,
                AchievedResult=achievedResult,
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }
             
        public void Delete(string submissionId)
        {
            var submissionToDelete=this.db.Submissions
                .Find(submissionId);
            this.db.Submissions.Remove(submissionToDelete);
            this.db.SaveChanges();
        }
    }
}
