namespace EngineeringManagementSystem.API.DTOs
{
    public class ProductionItemDTO
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int ProjectNumber { get; set; }
        public int DocumentNumber { get; set; }
    }

}
