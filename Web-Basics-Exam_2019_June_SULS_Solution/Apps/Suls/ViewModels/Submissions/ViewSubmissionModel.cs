using System;
using System.Globalization;

namespace Suls.ViewModels.Submissions
{
    public class ViewSubmissionModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public int ProblemPoints { get; set; }

        public string ResultOverPoints => $"{this.AchievedResult} / {this.ProblemPoints}";

        public DateTime CreatedOn { get; set; }

        public string CreatedOnFormatted => this.CreatedOn.
            ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
    }
}
