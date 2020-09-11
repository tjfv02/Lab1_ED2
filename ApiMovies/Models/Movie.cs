using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMovies.Models
{
    public class Movie : IComparable
    {

        public string Director { get; set; }
        public float ImdbRating{ get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RottenTomatoesRating { get; set; }
        public string Title { get; set; }

        public int CompareTo(object obj)
        {
            var temp = obj as Movie;

            if (string.Compare(this.Title, temp.Title) == 0)
            {
                return 0;
            }
            else if (string.Compare(this.Title, temp.Title) == 1)
            {
                return 1;
            }
            if (string.Compare(this.Title, temp.Title) == -1)
            {
                return -1;
            }

            return 2;
        }


    }
}
