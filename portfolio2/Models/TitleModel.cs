namespace WebServer.Models
{
    public class TitleModel
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string? Poster { get; set; }
        public string? Name { get; set; }
        public double WeightAvgRating { get; set; }
    }
}