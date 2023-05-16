using System.ComponentModel.DataAnnotations;

namespace UniRate.Models
{
    public class University
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? LogoUrl { get; set; }

        public string? BackroundPhotoUrl { get; set; }

        public string? Dean { get; set; }

        public string? Location { get; set;}

        public string? Address { get; set; }

        public string? SiteUrl { get; set; }

        public string? LocationUrl { get; set; }

        public string? Phone { get; set;}

        public string? ContactUrl { get; set;}

        public List<Department>? Departments { get; set; }

        public List<UniRating>? Ratings { get; set; }
    }
}