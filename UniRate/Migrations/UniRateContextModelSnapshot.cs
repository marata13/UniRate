﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UniRate.Data;

#nullable disable

namespace UniRate.Migrations
{
    [DbContext(typeof(UniRateContext))]
    partial class UniRateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UniRate.Models.DepRating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<int?>("DifficultyRating")
                        .HasColumnType("integer");

                    b.Property<int?>("FreshnessRating")
                        .HasColumnType("integer");

                    b.Property<int?>("OrganisationRating")
                        .HasColumnType("integer");

                    b.Property<int?>("OverallRating")
                        .HasColumnType("integer");

                    b.Property<int?>("ProfessorsRating")
                        .HasColumnType("integer");

                    b.Property<string>("Review")
                        .HasColumnType("text");

                    b.Property<int?>("SubjectsRating")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("DepRating");
                });

            modelBuilder.Entity("UniRate.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Directions")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int?>("EntranceGrade")
                        .HasColumnType("integer");

                    b.Property<string>("LocationUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("School")
                        .HasColumnType("text");

                    b.Property<string>("SiteUrl")
                        .HasColumnType("text");

                    b.Property<int?>("StudyDuration")
                        .HasColumnType("integer");

                    b.Property<int?>("SubjectCount")
                        .HasColumnType("integer");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("UniRate.Models.FavoriteDepartment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteDepartment");
                });

            modelBuilder.Entity("UniRate.Models.FavoriteUniversity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteUniversity");
                });

            modelBuilder.Entity("UniRate.Models.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Level")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Office")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("UniRate.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Hours")
                        .HasColumnType("text");

                    b.Property<Guid?>("ProfessorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Semester")
                        .HasColumnType("text");

                    b.Property<string>("SubjectUrl")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("UniRate.Models.UniRating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("AccessabilityRating")
                        .HasColumnType("integer");

                    b.Property<int?>("ActionsRating")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Locationrating")
                        .HasColumnType("integer");

                    b.Property<int?>("OrganisationRating")
                        .HasColumnType("integer");

                    b.Property<double?>("OverallRating")
                        .HasColumnType("double precision");

                    b.Property<string>("Review")
                        .HasColumnType("text");

                    b.Property<int?>("SchoolRating")
                        .HasColumnType("integer");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.HasIndex("UserId");

                    b.ToTable("UniRating");
                });

            modelBuilder.Entity("UniRate.Models.University", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("BackroundPhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("ContactUrl")
                        .HasColumnType("text");

                    b.Property<string>("Dean")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("LocationUrl")
                        .HasColumnType("text");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("SiteUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("University");
                });

            modelBuilder.Entity("UniRate.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("bytea");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("UniRate.Models.DepRating", b =>
                {
                    b.HasOne("UniRate.Models.Department", "department")
                        .WithMany("Ratings")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniRate.Models.User", "user")
                        .WithMany("DepRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");

                    b.Navigation("user");
                });

            modelBuilder.Entity("UniRate.Models.Department", b =>
                {
                    b.HasOne("UniRate.Models.University", "university")
                        .WithMany("Departments")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("university");
                });

            modelBuilder.Entity("UniRate.Models.FavoriteDepartment", b =>
                {
                    b.HasOne("UniRate.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniRate.Models.User", "User")
                        .WithMany("FavoriteDepartments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniRate.Models.FavoriteUniversity", b =>
                {
                    b.HasOne("UniRate.Models.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniRate.Models.User", "User")
                        .WithMany("FavoriteUniversities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniRate.Models.Professor", b =>
                {
                    b.HasOne("UniRate.Models.Department", "Department")
                        .WithMany("Professors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniRate.Models.Subject", b =>
                {
                    b.HasOne("UniRate.Models.Department", "Department")
                        .WithMany("Subjects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniRate.Models.Professor", "Professor")
                        .WithMany("Subjects")
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Department");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("UniRate.Models.UniRating", b =>
                {
                    b.HasOne("UniRate.Models.University", "University")
                        .WithMany("Ratings")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniRate.Models.User", "User")
                        .WithMany("UniRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniRate.Models.Department", b =>
                {
                    b.Navigation("Professors");

                    b.Navigation("Ratings");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("UniRate.Models.Professor", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("UniRate.Models.University", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("UniRate.Models.User", b =>
                {
                    b.Navigation("DepRatings");

                    b.Navigation("FavoriteDepartments");

                    b.Navigation("FavoriteUniversities");

                    b.Navigation("UniRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
