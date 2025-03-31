using Microsoft.EntityFrameworkCore;
using EngineeringManagementSystem.API.Models;


namespace EngineeringManagementSystem.API.Data
{
    public class EngineeringManegementDbContext : DbContext
    {
        public EngineeringManegementDbContext(DbContextOptions<EngineeringManegementDbContext> options)
    : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Revision> Revisions { get; set; }
        public DbSet<DocumentRelease> DocumentReleases { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Notification> Notifications { get; set; }



        
    }


}
