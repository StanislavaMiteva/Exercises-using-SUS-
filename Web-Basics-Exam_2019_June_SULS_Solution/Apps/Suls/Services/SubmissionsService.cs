using Suls.Data;
using Suls.ViewModels.Submissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;

        public SubmissionsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(AddSubmissionInputModel input, string creatorId, int points)
        {
            Random rnd = new Random();
            int achievedResult = rnd.Next(0, points);

            var submission =new Submission 
            {
                Code=input.Code,
                CreatedOn=DateTime.UtcNow,
                UserId=creatorId,
                ProblemId=input.ProblemId,
                AchievedResult=achievedResult,
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public IEnumerable<ViewSubmissionModel> All()
        {
            throw new NotImplementedException();
        }
    }
}
