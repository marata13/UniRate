using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniRate.Migrations
{
    /// <inheritdoc />
    public partial class AddedFavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteDepartment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteDepartment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteUniversity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteUniversity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteUniversity_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteUniversity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteDepartment_DepartmentId",
                table: "FavoriteDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteDepartment_UserId",
                table: "FavoriteDepartment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteUniversity_UniversityId",
                table: "FavoriteUniversity",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteUniversity_UserId",
                table: "FavoriteUniversity",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteDepartment");

            migrationBuilder.DropTable(
                name: "FavoriteUniversity");
        }
    }
}
