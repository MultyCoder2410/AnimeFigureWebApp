namespace AnimeFigureWebApp.Models
{

    public class Review
    {

        public int ReviewId { get; set; }
        public Collector? Owner { get; set; }
        public string? Text { get; set; }
        public AnimeFigure? Figure { get; set; }

    }

}
