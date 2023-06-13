namespace UniRate.Models
{
    public class DepReviewsAggregate
    {
        public int DifficultyRating { get; set; } = 0;

        public int ProfessorsRating { get; set; } = 0;

        public int SubjectsRating { get; set; } = 0;

        public int FreshnessRating { get; set; } = 0;

        public int OrganisationRating { get; set; } = 0;

        public double OverallRating { get; set; } = 0.0;
    }
}
