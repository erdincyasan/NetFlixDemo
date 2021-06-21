using System;
using System.Collections.Generic;

namespace Netflix.Entities
{
    public class Movie
    {
        public Guid MovieID { get; set; }
        public string MovieName { get; set; }
        public string MoviePhoto { get; set; }
        public int MovieWatched { get; set; }
        public int MovieStar { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt
        {
            get; set;
        } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<MovieCategory> MovieCategories { get; set; }
    }

}
