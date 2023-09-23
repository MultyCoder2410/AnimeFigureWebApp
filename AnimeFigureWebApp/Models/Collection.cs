namespace AnimeFigureWebApp.Models
{

    public class Collection
    {

        public int CollectionId { get; set; }
        public int OwnerId {  get; set; }
        public List<Collector>? Collectors { get; set; }
        public List<AnimeFigure>? Figures { get; set; }
        public string? Name { get; set; }
        public float TotalValue { get; set; }
        public float TotalPrice { get; set; }

        public float CalculateDiffrence() { return TotalValue - TotalPrice; }

    }

}
