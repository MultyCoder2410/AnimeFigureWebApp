using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimeFigureWebApp.Data;
using AnimeFigureWebApp.Models;
using Type = AnimeFigureWebApp.Models.Type;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace AnimeFigureWebApp.Controllers
{
    public class CatalogController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// Gets database context so we can communicate with the database.
        /// </summary>
        /// <param name="context">Database context</param>
        public CatalogController(ApplicationDbContext context)
        {

            dbContext = context;

        }

        /// <summary>
        /// Gets list of anime figures based on filter and search results.
        /// </summary>
        /// <param name="searchTerm">Name or part of the name of the figure you are searching for</param>
        /// <param name="brands">The brand of the figures you are searching for</param>
        /// <param name="types">The type of the figures you are searching for</param>
        /// <param name="origins">The origins of the figures you are searching for</param>
        /// <returns>View with an AnimeFigureModel</returns>
        public async Task<IActionResult> Index(string searchTerm, string brands, string types, string origins)
        {

            IQueryable<AnimeFigure>? figures = dbContext?.Figures;

            if (figures != null)
            {

                if (!string.IsNullOrEmpty(searchTerm))
                    figures = figures.Where(f => f.Name != null && f.Name.Contains(searchTerm));

                if (brands != null && brands.Length > 0)
                {

                    string[] allBrands = brands.Split(',');
                    figures = figures.Where(f => f.Brand != null && allBrands.Contains(f.Brand.BrandId.ToString()));

                }

                if (types != null && types.Length > 0)
                {

                    string[] allTypes = types.Split(',');
                    figures = figures.Where(f => f.Type != null && allTypes.Contains(f.Type.TypeId.ToString()));

                }

                if (origins != null && origins.Length > 0)
                {

                    string[] allOrigins = origins.Split(',');
                    var filteredFigures = figures.Include(f => f.Origins).AsEnumerable().Where(f => f.Origins != null && f.Origins.Any(origin => allOrigins.Contains(origin.OriginId.ToString()))).Select(f => f.AnimeFigureId); 
                    figures = figures.Where(f => filteredFigures.Contains(f.AnimeFigureId));

                }

            }

            AnimeFigureModel figureModel = new AnimeFigureModel(

                Figures: await (figures?.ToListAsync() ?? Task.FromResult<List<AnimeFigure>>(new List<AnimeFigure>())),
                Types: await (dbContext?.Types.ToListAsync() ?? Task.FromResult<List<Type>>(new List<Type>())),
                Brands: await (dbContext?.Brands.ToListAsync() ?? Task.FromResult<List<Brand>>(new List<Brand>())),
                Origins: await (dbContext?.Origins.ToListAsync() ?? Task.FromResult<List<Origin>>(new List<Origin>()))
                
            );

            return dbContext?.Figures != null ? View(figureModel) : Problem("Entity set 'ApplicationDbContext.Figures'  is null.");

        }

        /// <summary>
        /// This gets the details from the anime figure selected.
        /// </summary>
        /// <param name="id">Id of figure to get from database</param>
        /// <returns>View with the anime figure</returns>
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || dbContext.Figures == null)
                return NotFound();

            var animeFigure = await dbContext.Figures.Include(f => f.Brand).Include(f => f.Type).Include(f => f.Origins).FirstOrDefaultAsync(m => m.AnimeFigureId == id);

            if (animeFigure == null)
                return NotFound();

            return View(animeFigure);

        }

        /// <summary>
        /// Shows create page for anime figure.
        /// </summary>
        /// <returns>View with NewFigureModel</returns>
        public IActionResult Create()
        {

            NewFigureModel model = new NewFigureModel(

                Figure: new AnimeFigure(),
                Brands: dbContext.Brands.ToList(),
                Types: dbContext.Types.ToList(),
                Origins: dbContext.Origins.ToList()

            );

            return View(model);

        }

        /// <summary>
        /// Handles creation of anime figure.
        /// </summary>
        /// <param name="Figure">Contains name, value and price of figure</param>
        /// <param name="brandName">The name of the brand of the figure</param>
        /// <param name="typeName">The type of the figure</param>
        /// <returns>View of NewFigureModel or redirection to Index page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnimeFigure Figure, string brandName, string typeName, string selectedOrigins)
        {

            if (ModelState.IsValid)
            {

                string[] allSelectedOrigins = selectedOrigins.Split(",");

                Figure.Brand = await dbContext.Brands.SingleOrDefaultAsync(b => b.Name == brandName);
                Figure.Type = await dbContext.Types.SingleOrDefaultAsync(t => t.Name == typeName);
                Figure.Origins = await dbContext.Origins.Where(o => allSelectedOrigins.Contains(o.Name)).ToListAsync<Origin>();

                if (Figure.Brand == null)
                    dbContext.Add(new Brand() { Name = brandName });

                if (Figure.Type == null)
                    dbContext.Add(new Type() { Name = typeName });

                if (Figure.Origins == null)
                {

                    foreach (string originName in allSelectedOrigins)
                        dbContext.Add(new Origin() { Name = originName });

                }

                dbContext.Add(Figure);
                await dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            NewFigureModel model = new NewFigureModel(

                Figure: Figure,
                Brands: dbContext.Brands.ToList(),
                Types: dbContext.Types.ToList(),
                Origins: dbContext.Origins.ToList()

            );

            return View(model);

        }

        /// <summary>
        /// Shows delete page for anime figure.
        /// </summary>
        /// <param name="id">Id of anime figure to be deleted</param>
        /// <returns>View with AnimeFigure</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null || dbContext.Figures == null)
                return NotFound();

            var animeFigure = await dbContext.Figures.FirstOrDefaultAsync(m => m.AnimeFigureId == id);

            if (animeFigure == null)
                return NotFound();

            return View(animeFigure);

        }

        /// <summary>
        /// Deletes anime figure from database.
        /// </summary>
        /// <param name="id">Id of anime figure to be deleted</param>
        /// <returns>Redirect to Index page</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (dbContext.Figures == null)
                return Problem("Entity set 'ApplicationDbContext.Figures'  is null.");

            var animeFigure = await dbContext.Figures.FindAsync(id);

            if (animeFigure != null)
                dbContext.Figures.Remove(animeFigure);
            
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if anime figure with id exists in database.
        /// </summary>
        /// <param name="id">Id of anime figure to check for</param>
        /// <returns>If anime figure exists</returns>
        private bool AnimeFigureExists(int id) { return (dbContext.Figures?.Any(e => e.AnimeFigureId == id)).GetValueOrDefault(); }

    }

}
