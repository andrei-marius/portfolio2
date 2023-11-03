namespace WebServer.Models
{
    internal class RatingModel
    {
        // An attempt at structuring the DTO 
        public string Url { get; set; }
        public string Id { get; set; }
        public object Rating { get; set; }
    }
}