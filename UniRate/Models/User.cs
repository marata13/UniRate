using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UniRate.Data;

namespace UniRate.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [RegularExpression(@"\w*")]
        public string? UserName { get; set; }

        //Password must contain at least one uppercase letter, one lowercase letter, one number and one special character
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public Byte[]? Salt { get; set; }

        public List<FavoriteUniversity>? FavoriteUniversities { get; set; }

        public List<FavoriteDepartment>? FavoriteDepartments { get; set; }

        public List<UniRating>? UniRatings { get; set; }

        public List<DepRating>? DepRatings { get; set; }


        public List<FavoriteUniversity> GetFavoriteUniversities(UniRateContext _context, bool includeUnies = false)
        {
            if (includeUnies)
            {
                return _context.FavoriteUniversity.Include(f => f.University)
                    .Where(b => b.UserId == Id).ToList();
            }
            return _context.FavoriteUniversity
                    .Where(b => b.UserId == Id).ToList();
        }


        public List<FavoriteDepartment> GetFavoriteDepartments(UniRateContext _context, bool includeDeps = false)
        {
            if (includeDeps)
            {
                return _context.FavoriteDepartment.Include(f => f.Department).Include(f => f.Department.university)
                    .Where(b => b.UserId == Id).ToList();
            }
            return _context.FavoriteDepartment
                    .Where(b => b.UserId == Id).ToList();
        }


        public List<UniRating> GetUniRatings(UniRateContext _context)
        {
            return _context.UniRating
                    .Where(b => b.UserId == Id).ToList();
        }


        public List<DepRating> GetDepRatings(UniRateContext _context)
        {
            return _context.DepRating
                    .Where(b => b.UserId == Id).ToList();
        }
    }
}