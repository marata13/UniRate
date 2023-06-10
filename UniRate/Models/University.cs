using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniRate.Data;

namespace UniRate.Models
{
    public class University
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? LogoUrl { get; set; }

        public string? BackroundPhotoUrl { get; set; }

        public string? Dean { get; set; }

        public string? Location { get; set; }

        public string? Address { get; set; }

        public string? SiteUrl { get; set; }

        public string? LocationUrl { get; set; }

        public string? Phone { get; set; }

        public string? ContactUrl { get; set; }

        public List<Department>? Departments { get; set; }

        public List<UniRating>? Ratings { get; set; }


        public List<Department> GetDepartments(UniRateContext _context)
        {
            return _context.Department
                    .Where(b => b.UniversityId == Id).ToList();
        }


        public IEnumerable<IGrouping<string, Department>> GetDepartmentsBySchool(UniRateContext _context)
        {
            List<Department> _departments = GetDepartments(_context);

            return from department in _departments
                   group department by department.School into newGroup
                   orderby newGroup.Key
                   select newGroup;
        }


        public List<UniRating> GetRatings(UniRateContext _context)
        {
            return _context.UniRating
                    .Where(b => b.UniversityId == Id).ToList();
        }


        public UniReviewsAggregate GetReviewsAggregate(UniRateContext _context)
        {
            List<UniRating> _ratings = GetRatings(_context);

            UniReviewsAggregate reviewsAggregate = new();

            if (_ratings != null && _ratings.Count > 0)
            {
                reviewsAggregate.AccessabilityRating = (int)Math.Round((double)_ratings.Select(rating => rating.AccessabilityRating).ToList().Average());
                reviewsAggregate.ActionsRating = (int)Math.Round((double)_ratings.Select(rating => rating.ActionsRating).ToList().Average());
                reviewsAggregate.Locationrating = (int)Math.Round((double)_ratings.Select(rating => rating.Locationrating).ToList().Average());
                reviewsAggregate.SchoolRating = (int)Math.Round((double)_ratings.Select(rating => rating.SchoolRating).ToList().Average());
                reviewsAggregate.OrganisationRating = (int)Math.Round((double)_ratings.Select(rating => rating.OrganisationRating).ToList().Average());
                reviewsAggregate.OverallRating = Math.Round((double)_ratings.Select(rating => rating.OverallRating).ToList().Average(), 2);
            }
            return reviewsAggregate;
        }
    }
}