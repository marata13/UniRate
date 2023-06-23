using Microsoft.EntityFrameworkCore;
using UniRate.Data;

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

        public Guid? UniversityId { get; set; }

        public University? university { get; set; }

        public List<Professor>? Professors { get; set; }

        public List<Subject>? Subjects { get; set; }

        public List<DepRating>? Ratings { get; set; }


        public List<DepRating> GetRatings(UniRateContext _context)
        {
            return _context.DepRating.Include(a => a.user)
                    .Where(b => b.DepartmentId == Id).ToList();
        }


        public DepReviewsAggregate GetReviewsAggregate(UniRateContext _context)
        {
            List<DepRating> _ratings = GetRatings(_context);

            DepReviewsAggregate reviewsAggregate = new();

            if (_ratings != null && _ratings.Count > 0)
            {
                reviewsAggregate.DifficultyRating = (int)Math.Round((double)_ratings.Select(rating => rating.DifficultyRating).ToList().Average());
                reviewsAggregate.ProfessorsRating = (int)Math.Round((double)_ratings.Select(rating => rating.ProfessorsRating).ToList().Average());
                reviewsAggregate.SubjectsRating = (int)Math.Round((double)_ratings.Select(rating => rating.SubjectsRating).ToList().Average());
                reviewsAggregate.FreshnessRating = (int)Math.Round((double)_ratings.Select(rating => rating.FreshnessRating).ToList().Average());
                reviewsAggregate.OrganisationRating = (int)Math.Round((double)_ratings.Select(rating => rating.OrganisationRating).ToList().Average());
                reviewsAggregate.OverallRating = Math.Round((double)_ratings.Select(rating => rating.OverallRating).ToList().Average(), 2);
            }
            return reviewsAggregate;
        }


        public IEnumerable<IGrouping<string, Subject>> GetSubjectsBySemester(UniRateContext _context)
        {
            List<Subject> _subjects = GetSubjects(_context);

            return from subject in _subjects
                   group subject by subject.Semester into newGroup
                   orderby newGroup.Key
                   select newGroup;
        }

        private List<Subject> GetSubjects(UniRateContext _context)
        {
            return _context.Subject.Include(a => a.Professor)
                    .Where(b => b.DepartmentId == Id).ToList();
        }


        public static IEnumerable<TopRatedDep> GetTopRatedDepartments(UniRateContext _context)
        {
            List<Department> departments = _context.Department.Include(u => u.university).ToList();

            List<TopRatedDep> depsToSort = new();

            foreach (var dep in departments)
            {
                List<DepRating> _ratings = dep.GetRatings(_context);

                if (_ratings.Count > 0)
                {
                    TopRatedDep topRated = new();
                    topRated.Department = dep;

                    topRated.Rating = Math.Round((double)_ratings.Select(rating => rating.OverallRating).ToList().Average(), 2);
                    topRated.ReviewCount = _ratings.Count;

                    depsToSort.Add(topRated);
                }
            }

            return depsToSort.OrderByDescending(o => o.Rating).Take(5);
        }
    }
}