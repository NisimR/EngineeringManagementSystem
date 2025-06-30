namespace EngineeringManagementSystem.API.DTOs
{
    public class ProductionItemDTO
    {
        public int ProductionItemId { get; set; }
        public int DocumentId { get; set; }
        public string? DocumentName { get; set; }  // שם המסמך
        public string? PartName { get; set; }
        public int ProductionProjectId { get; set; }
        public string? ProductionProjectName { get; set; } // שם פרויקט
        public int Quantity { get; set; }
        public int CreatedById { get; set; }
        public string? CreatedByName { get; set; } // שם המשתמש שיצר
        public DateTime CreatedAt { get; set; }
    }


}
