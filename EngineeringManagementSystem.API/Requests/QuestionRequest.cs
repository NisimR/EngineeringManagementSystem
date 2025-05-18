namespace EngineeringManagementSystem.API.Requests
{
    

    public class QuestionRequest
    {
        public int AskedByUserId { get; set; }
        public int ProductionProjectId { get; set; }
        public int DocumentRevisionId { get; set; }
        public string QuestionText { get; set; }


        


    }

}
