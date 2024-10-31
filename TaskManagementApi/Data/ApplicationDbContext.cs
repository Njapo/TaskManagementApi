using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Models;

namespace TaskManagementApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<LocalUser> LocalUsers{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectTask>().HasData(
                new ProjectTask
                {
                    Id = 1,
                    Name = "Initial Setup",
                    Description = "Setting up the project structure and initial configurations.",
                    StartDate = new DateTime(2024, 10, 1),
                    EndDate = new DateTime(2024, 10, 5),
                    IsCompleted = true
                },
                new ProjectTask
                {
                    Id = 2,
                    Name = "Database Design",
                    Description = "Designing the database schema and establishing relationships.",
                    StartDate = new DateTime(2024, 10, 6),
                    EndDate = new DateTime(2024, 10, 10),
                    IsCompleted = false
                },
                new ProjectTask
                {
                    Id = 3,
                    Name = "API Development",
                    Description = "Developing RESTful APIs for the application backend.",
                    StartDate = new DateTime(2024, 10, 11),
                    EndDate = new DateTime(2024, 10, 20),
                    IsCompleted = false
                },
                new ProjectTask
                {
                    Id = 4,
                    Name = "Frontend Implementation",
                    Description = "Implementing frontend features and integrating with APIs.",
                    StartDate = new DateTime(2024, 10, 21),
                    EndDate = new DateTime(2024, 10, 30),
                    IsCompleted = false
                },
                new ProjectTask
                {
                    Id = 5,
                    Name = "Testing and QA",
                    Description = "Conducting thorough testing and quality assurance.",
                    StartDate = new DateTime(2024, 11, 1),
                    EndDate = new DateTime(2024, 11, 5),
                    IsCompleted = false
                }
            );
        }
    }
}
