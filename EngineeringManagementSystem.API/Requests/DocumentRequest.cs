namespace EngineeringManagementSystem.API.Requests
{
    public class DocumentRequest
    {
        //public int DocumentId { get; set; }
        public int PartNumberDoc { get; set; }
        public string PathDoc { get; set; }
        public string DocName { get; set; }

        //public char Rev { get; set; }
        public string AuthorName { get; set; }
        public string ReviewerName { get; set; }
        public string ApproverName { get; set; }
        

        
    }
}
