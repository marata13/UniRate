namespace UniRate.Models
{
    public class DepRating
    {
        public Guid Id { get; set; }

        public int? DifficultyRating { get; set; }

        public int? ProfessorsRating { get; set; }

        public int? SubjectsRating { get; set; }    

        public int? FreshnessRating { get; set; }

        public int? OrganisationRating { get; set; }

        public int? OverallRating { get; set; }

        public string? Review { get; set; }

        public DateTime? DateTime { get; set; }
    }
}