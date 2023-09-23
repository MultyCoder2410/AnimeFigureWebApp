namespace AnimeFigureWebApp.Models
{

    public class Category
    {

        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public List<AnimeFigure>? Figures { get; set; }

    }

}
