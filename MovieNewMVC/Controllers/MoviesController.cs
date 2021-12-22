using MovieNewMVC.Models;
using MovieNewMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MovieNewMVC.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);

        }
        public ActionResult New()
        {
            // fetch Genre from database and assign for drop down list
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // this action method is for add new or update data
        public ActionResult Save(Movie movie)   
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NoInStock = movie.NoInStock;
                movieInDb.GenreId = movie.GenreId; 
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e) ;
            }
            
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm",viewModel);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(n =>n.Genre).FirstOrDefault(m => m.Id == id);
            return View(movie);
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shark !" };

            var customers = new List<Customer>
            {
                new Customer{ Name = "Customer 1"},
                new Customer{Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
            //return View(movie);

            //ViewData["Movie"] = movie;

            //ViewBag.Movie = movie;
            //return View();            
        }
        
        // int ? for optional parameter - nullable integer 
        // string type in c# is referense type and its a nullable
        /*
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex = {0} & soryby ={1}", pageIndex, sortBy));
        }
        */
        [Route("movies/released/{year}/{month:regex(\\d{4}) : range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}