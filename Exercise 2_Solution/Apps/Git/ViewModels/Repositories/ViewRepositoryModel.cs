using System;
using System.Globalization;

namespace Git.ViewModels.Repositories
{
    public class ViewRepositoryModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => this.CreatedOn.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

        public string OwnerName { get; set; }

        public int CommitsCount { get; set; }
    }
}
