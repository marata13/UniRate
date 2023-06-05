namespace UniRate.Models
{
    public class FavoriteUniversity
    {
        public Guid Id { get; set; }

        public University University { get; set; }

        public Guid UniversityId { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}