using Microsoft.EntityFrameworkCore;

namespace Project.WEB.Models.Project
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
            
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Software> Softwares { get; set; }

        public class Project
        {
            public int Id { get; set; }
            public int? ClientId { get; set; }
            public string UserUuid { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal PricePerHour { get; set; }
            
        }

        public class Client
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Software
        {
            public int Id { get; set; }
            public int? ProjectId { get; set; }
            public string ProcessName { get; set; }
            public string TitleName { get; set; }
            public decimal TimeSpent { get; set; }
        }

    }
}
