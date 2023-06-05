using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniRate.Migrations
{
    /// <inheritdoc />
    public partial class Cleaningupforeignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_University_UniversityId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_DepRating_Department_DepartmentId",
                table: "DepRating");

            migrationBuilder.DropForeignKey(
                name: "FK_DepRating_User_UserId",
                table: "DepRating");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteDepartment_User_UserId",
                table: "FavoriteDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteUniversity_User_UserId",
                table: "FavoriteUniversity");

            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Department_DepartmentId",
                table: "Professor");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Department_DepartmentId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_UniRating_University_UniversityId",
                table: "UniRating");

            migrationBuilder.DropForeignKey(
                name: "FK_UniRating_User_UserId",
                table: "UniRating");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UniRating",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UniversityId",
                table: "UniRating",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Subject",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Professor",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "FavoriteUniversity",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "FavoriteDepartment",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "DepRating",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "DepRating",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UniversityId",
                table: "Department",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                table: "User",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_University_UniversityId",
                table: "Department",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepRating_Department_DepartmentId",
                table: "DepRating",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepRating_User_UserId",
                table: "DepRating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteDepartment_User_UserId",
                table: "FavoriteDepartment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteUniversity_User_UserId",
                table: "FavoriteUniversity",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Department_DepartmentId",
                table: "Professor",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Department_DepartmentId",
                table: "Subject",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniRating_University_UniversityId",
                table: "UniRating",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniRating_User_UserId",
                table: "UniRating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_University_UniversityId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_DepRating_Department_DepartmentId",
                table: "DepRating");

            migrationBuilder.DropForeignKey(
                name: "FK_DepRating_User_UserId",
                table: "DepRating");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteDepartment_User_UserId",
                table: "FavoriteDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteUniversity_User_UserId",
                table: "FavoriteUniversity");

            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Department_DepartmentId",
                table: "Professor");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Department_DepartmentId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_UniRating_University_UniversityId",
                table: "UniRating");

            migrationBuilder.DropForeignKey(
                name: "FK_UniRating_User_UserId",
                table: "UniRating");

            migrationBuilder.DropIndex(
                name: "IX_User_UserName",
                table: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UniRating",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "UniversityId",
                table: "UniRating",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Subject",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Professor",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "FavoriteUniversity",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "FavoriteDepartment",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "DepRating",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "DepRating",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "UniversityId",
                table: "Department",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_University_UniversityId",
                table: "Department",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepRating_Department_DepartmentId",
                table: "DepRating",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepRating_User_UserId",
                table: "DepRating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteDepartment_User_UserId",
                table: "FavoriteDepartment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteUniversity_User_UserId",
                table: "FavoriteUniversity",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Department_DepartmentId",
                table: "Professor",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Department_DepartmentId",
                table: "Subject",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UniRating_University_UniversityId",
                table: "UniRating",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UniRating_User_UserId",
                table: "UniRating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
