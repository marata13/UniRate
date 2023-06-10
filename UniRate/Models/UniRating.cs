﻿namespace UniRate.Models
{
    public class UniRating
    {
        public Guid Id { get; set; }

        public int? SchoolRating { get; set; }

        public int? ActionsRating { get; set; }

        public int? Locationrating { get; set; }

        public int? AccessabilityRating { get; set; }

        public int? OrganisationRating { get; set; }

        public double? OverallRating { get; set; }

        public string? Review { get; set; }

        public DateTime? DateTime { get; set; }

        public Guid UserId { get; set; }

        public User? User { get; set; }

        public Guid UniversityId { get; set; }

        public University? University { get; set; }
    }
}