using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseService
{
    public class DataService
    {
        public List<Category> GetCategories()
        {
            using var db = new NorthwindContex();
            return db.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            using var db = new NorthwindContex();
            return db.Categories.Find(id);
        }
    }
}
