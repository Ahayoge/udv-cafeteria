﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UDV_Benefits.Infrastructure.Data;

#nullable disable

namespace UDV_Benefits.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UDV_Benefits.Domain.Models.Benefit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ExperienceYearsRequired")
                        .HasColumnType("integer");

                    b.Property<string>("FormUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("OnboardingRequired")
                        .HasColumnType("boolean");

                    b.Property<int>("RealPrice")
                        .HasColumnType("integer");

                    b.Property<int?>("UcoinPrice")
                        .HasColumnType("integer");

                    b.Property<int>("ValidityPeriodDays")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.BenefitRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("AppliedWhen")
                        .HasColumnType("date");

                    b.Property<Guid>("BenefitId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("StatusChangedWhen")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("BenefitId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("BenefitRequests");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsOnboarded")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("StartedWorkWhen")
                        .HasColumnType("date");

                    b.Property<int>("Ucoins")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.EmployeeBenefit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("ActivatedWhen")
                        .HasColumnType("date");

                    b.Property<Guid>("BenefitId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("DeactivatedWhen")
                        .HasColumnType("date");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BenefitId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeBenefits");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.Benefit", b =>
                {
                    b.HasOne("UDV_Benefits.Domain.Models.Category", "Category")
                        .WithMany("Benefits")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.BenefitRequest", b =>
                {
                    b.HasOne("UDV_Benefits.Domain.Models.Benefit", "Benefit")
                        .WithMany("BenefitRequests")
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDV_Benefits.Domain.Models.Employee", "Employee")
                        .WithMany("BenefitRequests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benefit");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.Employee", b =>
                {
                    b.HasOne("UDV_Benefits.Domain.Models.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("UDV_Benefits.Domain.Models.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.EmployeeBenefit", b =>
                {
                    b.HasOne("UDV_Benefits.Domain.Models.Benefit", "Benefit")
                        .WithMany("EmployeeBenefits")
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDV_Benefits.Domain.Models.Employee", "Employee")
                        .WithMany("EmployeeBenefits")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benefit");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.UserRole", b =>
                {
                    b.HasOne("UDV_Benefits.Domain.Models.User", "User")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.Benefit", b =>
                {
                    b.Navigation("BenefitRequests");

                    b.Navigation("EmployeeBenefits");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.Category", b =>
                {
                    b.Navigation("Benefits");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.Employee", b =>
                {
                    b.Navigation("BenefitRequests");

                    b.Navigation("EmployeeBenefits");
                });

            modelBuilder.Entity("UDV_Benefits.Domain.Models.User", b =>
                {
                    b.Navigation("Employee")
                        .IsRequired();

                    b.Navigation("UsersRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
