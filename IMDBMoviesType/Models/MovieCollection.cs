using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IMDBMoviesType.Models
{
     
    public class MovieCollection :DbContext
    {
        public DbSet<Movie> Movie { get; set; }
    }
}