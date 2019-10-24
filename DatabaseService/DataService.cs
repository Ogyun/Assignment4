﻿using System;
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

        public Category CreateCategory(string name, string description)
        {
            using var db = new NorthwindContex();
            var nextId = db.Categories.Max(x => x.Id) + 1;
            
            var category = new Category
            {
                Id = nextId,
                Name = name,
                Description = description
            };

            db.Categories.Add(category);
            int changes = db.SaveChanges();
            if (changes > 0)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public bool DeleteCategory(int id)
        {
            using var db = new NorthwindContex();
            if (id > 0)
            {
                var category = db.Categories.Find(id);
                if (category != null)
                {
                    db.Categories.Remove(category);
                    int changes = db.SaveChanges();
                    if (changes > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
               
                
            }
            else
            {
                return false;
            }
           
        }
        public bool UpdateCategory(int id , string name, string description)
        {
            using var db = new NorthwindContex();
            if (id > 0)
            {
                var category = db.Categories.Find(id);
                if (category != null)
                {
                    category.Id = id;
                    category.Name = name;
                    category.Description = description;
                    int changes = db.SaveChanges();
                    if (changes > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
               
            }
            else
            {
                return false;
            }

        }
    }
}
