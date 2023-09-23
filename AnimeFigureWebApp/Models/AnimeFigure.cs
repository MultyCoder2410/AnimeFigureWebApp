namespace AnimeFigureWebApp.Models
{

    public class AnimeFigure
    {

        public int AnimeFigureId { get; set; }
        public string? Name {  get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public float Value { get; set; }
        public Brand? Brand {  get; set; }
        public Type? Type {  get; set; }
        public List<Origin>? Origins { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Review>? Reviews { get; set; }

    }

}
