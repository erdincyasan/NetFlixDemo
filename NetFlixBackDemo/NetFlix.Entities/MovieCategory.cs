using System;

namespace Netflix.Entities
{
    public class MovieCategory
    {
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public Guid MovieID { get; set; }
        public Movie Movie { get; set; }
    }
}
