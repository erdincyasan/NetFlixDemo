using System;
using System.Collections.Generic;

namespace Netflix.Entities
{
    public class Category
    {
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Guid UserID { get; set; }
        public User WhoCreate { get; set; }
        public DateTime CreatedAt
        {
            get; set;
        } = DateTime.Now;
        public DateTime UpdatedAt
        {
            get; set;
        }
        public List<MovieCategory> MovieCategories { get; set; }
    }
}
