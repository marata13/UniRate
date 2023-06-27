using System.ComponentModel.DataAnnotations;

namespace UniRate.Models
{
    public class UniRating
    {
        public Guid Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int SchoolRating { get; set; }

        [Required]
        [Range(1, 5)]
        public int ActionsRating { get; set; }

        [Required]
        [Range(1, 5)]
        public int Locationrating { get; set; }

        [Required]
        [Range(1, 5)]
        public int AccessabilityRating { get; set; }

        [Required]
        [Range(1, 5)]
        public int OrganisationRating { get; set; }

        public double? OverallRating { get; set; }

        [RegularExpression(@"\w*")]
        public string? Review { get; set; }

        public DateTime? DateTime { get; set; }

        public Guid UserId { get; set; }

        public User? User { get; set; }

        public Guid UniversityId { get; set; }

        public University? University { get; set; }
    }
}