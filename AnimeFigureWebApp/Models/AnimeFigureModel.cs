namespace AnimeFigureWebApp.Models;

public record AnimeFigureModel
(

    IList<AnimeFigure> Figures,
    IList<Type> Types,
    IList<Brand> Brands,
    IList<Origin> Origins
    
);