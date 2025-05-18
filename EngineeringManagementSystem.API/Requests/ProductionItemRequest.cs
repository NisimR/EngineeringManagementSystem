namespace EngineeringManagementSystem.API.Requests
{
    public class ProductionItemRequest
    {
        public int ProductionProjectId { get; set; }//מספר הפרויקט בייצור
        public int DocumentId { get; set; }//קישור למסמך
        //public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int CreatedById { get; set; }


        

       

    }
}
