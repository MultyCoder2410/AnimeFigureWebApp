namespace AnimeFigureWebApp.Models
{

    public class Collector
    {

        public int CollectorId { get; set; }
        public string? Name { get; set; }
        public List<Collection>? Collections { get; set; }

        public bool Login()
        {

            return true;

        }

        public void Logout()
        {



        }

        public void CreateCollection(string name)
        {



        }

        public void AddFigureToCollection(int collectionId, AnimeFigure animeFigure) 
        {
        

        
        }

        public void EditCollection(int collectionId, string name) 
        {
        
        

        }

        public void ShareCollection(int collectionId, Collector collector)
        {



        }

        public void DeleteCollection(int collectionId) 
        {
        
        
        
        }

        public void ReviewFigure(string text, AnimeFigure animeFigure)
        {

            

        }

        public void DeleteReview(int reviewId)
        {



        }

        public void AddFigure(string name, string description, float price, float value, Brand brand, Type type, Origin origin, List<Category> categories)
        {



        }

    }

}
