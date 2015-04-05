using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDBMoviesType.Models
{
    [Table("movie_collection ")]
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public string year { get; set; }
        public string rated { get; set; }
        public string released { get; set; }
        public string genre { get; set; }
        public string director { get; set; }
        public string writer { get; set; }
        public string actors { get; set; }
        public string plot { get; set; }
        public string poster { get; set; }
        public string runtime { get; set; }
        public string rating { get; set; }
        public string votes { get; set; }
        public string imdb { get; set; }
        public string tstamp { get; set; }

    }
}