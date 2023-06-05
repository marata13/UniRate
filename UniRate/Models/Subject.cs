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

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }

        public Guid? ProfessorId { get; set; }

        public Professor? Professor { get; set; }
    }
}