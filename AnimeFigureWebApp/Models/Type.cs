namespace AnimeFigureWebApp.Models
{

    public class Type
    {

        public int TypeId { get; set; }
        public string? Name { get; set; }
        public List<AnimeFigure>? Figures { get; set; }

    }

}
