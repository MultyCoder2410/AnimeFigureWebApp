namespace AnimeFigureWebApp.Models
{

    public class Admin
    {

        public int AdminId { get; set; }
        public List<Collector>? Collectors { get; set; }
        public List<AnimeFigure>? Figures { get; set; }

        void AddFigure(string name, string description, float price, float value, Brand brand, Type type, Origin origin, List<Category> categories)
        { 
        
            
        
        }

        void EditFigure(int figureId, string name, string description, float price, float value, Brand brand, Type type, Origin origin, List<Category> categories)
        {



        }

        void AcceptFigure(bool accept) 
        {
        
        
        
        }

    }

}
