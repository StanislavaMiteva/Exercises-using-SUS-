﻿namespace CarShop.ViewModels.Issues
{
    public class IssueViewModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public bool IsFixed { get; set; }

        public string IsFixedAsString => IsFixed ? "Yes" : "Not yet";

        public string CarId { get; set; }
    }
}
