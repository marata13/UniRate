namespace UniRate.Models
{
    public class FavoriteDepartment
    {
        public Guid Id { get; set; }

        public Department Department { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}