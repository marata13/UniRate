﻿using Microsoft.EntityFrameworkCore;

namespace UniRate.Data
{
    public class UniRateContext : DbContext
    {
        public UniRateContext(DbContextOptions<UniRateContext> options)
            : base(options)
        {
        }

        public DbSet<UniRate.Models.User> User { get; set; } = default!;

        public DbSet<UniRate.Models.Department> Department { get; set; } = default!;

        public DbSet<UniRate.Models.DepRating> DepRating { get; set; } = default!;

        public DbSet<UniRate.Models.Professor> Professor { get; set; } = default!;

        public DbSet<UniRate.Models.Subject> Subject { get; set; } = default!;

        public DbSet<UniRate.Models.UniRating> UniRating { get; set; } = default!;

        public DbSet<UniRate.Models.University> University { get; set; } = default!;

        public DbSet<UniRate.Models.FavoriteUniversity> FavoriteUniversity { get; set; } = default!;

        public DbSet<UniRate.Models.FavoriteDepartment> FavoriteDepartment { get; set; } = default!;
    }
}
