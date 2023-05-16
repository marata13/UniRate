namespace UniRate.Models
{
    public class Subject
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Semester { get; set; }

        public string? Type { get; set; }

        public string? Hours { get; set; }

        public string? SubjectUrl { get; set; }
    }
}