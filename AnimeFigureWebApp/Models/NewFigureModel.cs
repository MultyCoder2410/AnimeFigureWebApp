namespace AnimeFigureWebApp.Models;

public record NewFigureModel
(

    AnimeFigure Figure,
    IList<Type> Types,
    IList<Brand> Brands,
    IList<Origin> Origins

);