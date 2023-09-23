namespace AnimeFigureWebApp.Models
{

    public class Origin
    {

        public int OriginId { get; set; }
        public string? Name { get; set; }
        public List<AnimeFigure>? Figures { get; set; }

    }

}
