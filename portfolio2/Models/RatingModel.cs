namespace WebServer.Models
{
    public class RatingModel
    {
        // An attempt at structuring the DTO 
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public int Rating { get; set; }
    }
}