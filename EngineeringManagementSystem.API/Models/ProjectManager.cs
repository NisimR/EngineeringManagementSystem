namespace EngineeringManagementSystem.API.Models
{
    public class ProjectManager : User
    {
        public int ProjectId { get; set; }   // מזהה הפרויקט שעליו המשתמש אחראי (מנהל הפרויקט)
                                             
        public Project ManagedProject { get; set; } 
    }
}
