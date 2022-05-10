using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CareerUpStudent.Models
{
    public partial class CareerUpStudentContext : DbContext
    {
        public CareerUpStudentContext()
        {
        }

        public CareerUpStudentContext(DbContextOptions<CareerUpStudentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyReview> CompanyReviews { get; set; }
        public virtual DbSet<EduProgram> EduPrograms { get; set; }
        public virtual DbSet<Hr> Hrs { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentReview> StudentReviews { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Favorites> FavoriteVacancies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-461J672;Initial Catalog=CareerUpDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(3999);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(3000);
            });

            modelBuilder.Entity<CompanyReview>(entity =>
            {
                entity.ToTable("CompanyReview");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments).HasMaxLength(1000);

                entity.Property(e => e.IdStudent).HasColumnName("ID_Student");

                entity.Property(e => e.IdVacancy).HasColumnName("ID_Vacancy");

                entity.Property(e => e.RatingStud).HasColumnName("Rating_Stud");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.CompanyReviews)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CompanyReview_Student");

                entity.HasOne(d => d.IdVacancyNavigation)
                    .WithMany(p => p.CompanyReviews)
                    .HasForeignKey(d => d.IdVacancy)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CompanyReview_Vacancy");
            });

            modelBuilder.Entity<EduProgram>(entity =>
            {
                entity.ToTable("EduProgram");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.EduLevel).HasMaxLength(1000);

                entity.Property(e => e.Faculty)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.IdUniversity).HasColumnName("ID_University");

                entity.Property(e => e.Program)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IdUniversityNavigation)
                    .WithMany(p => p.EduPrograms)
                    .HasForeignKey(d => d.IdUniversity)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EduProgram_University");
            });

            modelBuilder.Entity<Hr>(entity =>
            {
                entity.ToTable("HR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdCompany).HasColumnName("ID_Company");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Hrs)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_HR_Company");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("Reply");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnswerDate).HasColumnType("date");

                entity.Property(e => e.IdResume).HasColumnName("ID_Resume");

                entity.Property(e => e.IdVacancy).HasColumnName("ID_Vacancy");

                entity.HasOne(d => d.IdResumeNavigation)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.IdResume)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Reply_Resume");

                entity.HasOne(d => d.IdVacancyNavigation)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.IdVacancy)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Reply_Vacancy");
            });

            modelBuilder.Entity<Resume>(entity =>
            {
                entity.ToTable("Resume");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdStudent).HasColumnName("ID_Student");

                entity.Property(e => e.Link).HasMaxLength(3999);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Resumes)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Resume_Student");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EduForm)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.IdEduProgram).HasColumnName("ID_EduProgram");

                entity.Property(e => e.PlaceType)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.StudCode)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.StudGroup)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdEduProgramNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdEduProgram)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Student_EduProgram");
            });

            modelBuilder.Entity<StudentReview>(entity =>
            {
                entity.ToTable("StudentReview");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments).HasMaxLength(1000);

                entity.Property(e => e.IdStudent).HasColumnName("ID_Student");

                entity.Property(e => e.IdVacancy).HasColumnName("ID_Vacancy");

                entity.Property(e => e.RatingCompany).HasColumnName("Rating_Company");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.StudentReviews)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_StudentReview_Student");

                entity.HasOne(d => d.IdVacancyNavigation)
                    .WithMany(p => p.StudentReviews)
                    .HasForeignKey(d => d.IdVacancy)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_StudentReview_Vacancy");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.ToTable("University");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdHr).HasColumnName("ID_HR");

                entity.Property(e => e.IdRole).HasColumnName("ID_Role");

                entity.Property(e => e.IdStudent).HasColumnName("ID_Student");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Patronymic).HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdHrNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdHr)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_User_HR");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_User_Role");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_User_Student");
            });

            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.ToTable("Vacancy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Conditions)
                    .IsRequired()
                    .HasMaxLength(3999);

                entity.Property(e => e.Description).HasMaxLength(3999);

                entity.Property(e => e.EmploymentType).HasMaxLength(3999);

                entity.Property(e => e.ExperienceRequired).HasMaxLength(100);

                entity.Property(e => e.IdCompany).HasColumnName("ID_Company");

                entity.Property(e => e.IdHr).HasColumnName("ID_HR");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.PublicationDate).HasColumnType("date");

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasMaxLength(3999);

                entity.Property(e => e.Responsibilities)
                    .IsRequired()
                    .HasMaxLength(3999);

                entity.Property(e => e.Salary).HasMaxLength(1000);

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Vacancy_Company");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
