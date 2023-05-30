using System.ComponentModel.DataAnnotations;

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

        public string? Email { get; set; }

        public Byte[]? Salt { get; set; }

        public List<FavoriteUniversity>? FavoriteUniversities { get; set; }

        public List<FavoriteDepartment>? FavoriteDepartments { get; set; }

        public List<UniRating>? UniRatings { get; set; }

        public List<DepRating>? DepRatings { get; set; }
    }
}