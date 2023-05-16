namespace UniRate.Models
{
    public class Department
    {
        public Guid Id { get; set; }

        public string? School { get; set; }

        public string? Name { get; set; }

        public int? EntranceGrade { get; set; }

        public int? StudyDuration { get; set; }

        public string? Directions { get; set; }

        public int? SubjectCount { get; set; }

        public string? SiteUrl { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? LocationUrl { get; set; }

        public List<Professor>? Professors { get; set; }

        public List<Subject>? Subjects { get; set; }

        public List<DepRating>? Ratings { get; set; }
    }
}