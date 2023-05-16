namespace UniRate.Models
{
    public class Professor
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Level { get; set; }

        public string? Office { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public List<Subject>? Subjects { get; set; }
    }
}