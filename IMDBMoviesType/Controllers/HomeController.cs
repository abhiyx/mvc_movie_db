using IMDBMoviesType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDBMoviesType.Controllers
{
    public class HomeController : Controller
    {
        
        //Index Method used to Load Data on Index Controller
        public ActionResult Index()
        {
            try
            {
                MovieCollection moviecollection = new MovieCollection();
                List<Movie> movies = moviecollection.Movie.ToList();
                return View(movies);
            } 
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        /*Method For fetching data in order based on the linked clicked
         */

        public ActionResult MovieOrderBy(string rating,string released)
        {
            try{
            MovieCollection moviecollection = new MovieCollection();
            List<Movie> movies = new List<Movie>();
            if (rating != null)
            {
                movies = moviecollection.Movie.OrderByDescending(x => x.rating).ToList();
            }
            else
            {
                movies = moviecollection.Movie.OrderByDescending(x => x.released).ToList();
            }
            // List<Movie> movies = moviecollection.Movie.Where(x => x.actors.Contains(Actor)).ToList();           
            return View(movies);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        
        /*MovieSearch Method Search Movie Based on Parameter 
         This method will at a time receive only one parameter value and rest params will be null
         */
        public ActionResult MovieSearch(string Director, string Actor,string Year,string Genre)
        {
            try{
            MovieCollection moviecollection = new MovieCollection();
            List<Movie> movies = new List<Movie>();
            if (Director != null)
            {               
                 movies = moviecollection.Movie.Where(x => x.director == Director).ToList();
            }
            else if (Actor != null)
            {
                movies = moviecollection.Movie.Where(x => x.actors.Contains(Actor)).ToList();
            }
            else if (Year != null)
            {
                movies = moviecollection.Movie.Where(x => x.released.Contains(Year)).ToList();
            }
            else if (Genre != null)
            {
                movies = moviecollection.Movie.Where(x => x.genre.Contains(Genre)).ToList();
            }
            return View(movies);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        /*Method to fetch details of movies based on id
         */
        public ActionResult MovieDetail(string id)
        {
            try
            {
                MovieCollection moviecollection = new MovieCollection();
                //List<Movie> movies = moviecollection.Movie.ToList();
                Movie movies = moviecollection.Movie.FirstOrDefault(x => x.imdb == id);
               
                return View(movies);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        /*Error Handling Override the OnException function in case error occurs
         */
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception e = filterContext.Exception;
            //Log Exception e
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
        }
    }
}
