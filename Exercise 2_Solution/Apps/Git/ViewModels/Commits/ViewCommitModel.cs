using System;
using System.Globalization;

namespace Git.ViewModels.Commits
{
    public class ViewCommitModel
    {
        public string RepositoryName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => this.CreatedOn.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

        public string Id { get; set; }
    }
}
