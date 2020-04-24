using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The movies to display on the index page 
        /// </summary>
        public IEnumerable<Movie> Movies { get; protected set; }

        ///// <summary>
        ///// Stores search terms
        ///// </summary>
        //public string SearchTerms { get; set; }

        ///// <summary>
        ///// The filtered MPAA Ratings
        ///// </summary>
        //public string[] MPAARatings { get; set; }

        /// <summary>
        /// The current search terms 
        /// </summary>
        [BindProperty]
        public string SearchTerms { get; set; } = "";

        /// <summary>
        /// The filtered MPAA Ratings
        /// </summary>
        [BindProperty]
        public string[] MPAARatings { get; set; }

        /// <summary>
        /// The filtered genres
        /// </summary>
        [BindProperty]
        public string[] Genres { get; set; }

        /// <summary>
        /// The minimum IMDB Rating
        /// </summary>
        [BindProperty]
        public double? IMDBMin { get; set; }

        /// <summary>
        /// The maximum IMDB Rating
        /// </summary>
        [BindProperty]
        public double? IMDBMax { get; set; }

        /// <summary>
        /// The minimum Rotten Tomatoes Rating
        /// </summary>
        [BindProperty]
        public double? RTMin { get; set; }

        /// <summary>
        /// The maximum Rotten Tomatoes Rating
        /// </summary>
        [BindProperty]
        public double? RTMax { get; set; }

        /// <summary> 
        /// Get search results for page
        /// </summary>
        /// <param name="IMDBMin"></param>
        /// <param name="IMDBMax"></param>
        /// <param name="RTMin"></param>
        /// <param name="RTMax"></param>
        public void OnGet(double? IMDBMin, double? IMDBMax, double? RTMin, double? RTMax)
        {
            this.IMDBMin = IMDBMin;
            this.IMDBMax = IMDBMax;
            this.RTMin = RTMin;
            this.RTMax = RTMax;
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByGenre(Movies, Genres);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBMin, IMDBMax);
            Movies = MovieDatabase.FilterByRTRating(Movies, RTMin, RTMax);
        }
    }
}
