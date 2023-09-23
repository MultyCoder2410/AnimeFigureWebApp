namespace AnimeFigureWebApp.Models
{

    public class Brand
    {

        public int BrandId { get; set; }
        public string? Name { get; set; }
        public List<AnimeFigure>? Figures {  get; set; }

    }

}
