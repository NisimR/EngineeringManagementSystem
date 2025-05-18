using Microsoft.EntityFrameworkCore;
using EngineeringManagementSystem.API.Models;
using EngineeringManagementSystem.API.Enums;


namespace EngineeringManagementSystem.API.Data
{
    public class EngineeringManegementDbContext : DbContext
    {
        public EngineeringManegementDbContext(DbContextOptions<EngineeringManegementDbContext> options)
    : base(options) { }

        public DbSet<User> Users { get; set; }//משתמש
        public DbSet<Document> Documents { get; set; }//מסמך
       
        

        public DbSet<Question> Questions { get; set; }//שאלה


        public DbSet<Answer> Answers { get; set; }//תשובה
        public DbSet<Log> Logs { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<ProductionItem> ProductionItems { get; set; }

        public DbSet<EngineeringProject> EngineeringProjects { get; set; }

        public DbSet<ProductionProject> ProductionProjects { get; set; }


        






    }


}
