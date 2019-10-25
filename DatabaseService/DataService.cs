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

        public Product GetProduct(int id)
        {
            using var db = new NorthwindContex();
            var product = db.Products.Find(id);
            product.Category = GetCategory(product.CategoryId);
            return product;
        }

        public List<Product> GetProductByCategory(int id)
        {
            using var db = new NorthwindContex();         
            var pList = db.Products.Where(x => x.CategoryId == id);

            var products = pList.ToList();
            foreach (var product in products)
            {
                product.Category = GetCategory(product.CategoryId);
             
            }
            return products;
        }

        public List<Product> GetProductByName(string name)
        {
            using var db = new NorthwindContex();
            var pList = db.Products.Where(x => x.Name.Contains(name));
            var products = pList.ToList();
            return products;
        }

        public Order GetOrder(int id)
        {
            using var db = new NorthwindContex();
            var order = db.Orders.Find(id);
            order.OrderDetails = GetOrderDetailsByOrderId(id);
            return order;

        }

        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            using var db = new NorthwindContex();
            var orderDetailsList = db.OrderDetails.Where(x => x.OrderId == id) ;
            foreach (var orderDetail in orderDetailsList)
            {
                orderDetail.Product = GetProduct(orderDetail.ProductId);
                orderDetail.Product.Category = GetCategory(orderDetail.Product.CategoryId);
            }
            return orderDetailsList.ToList();

        }

        public List<Order> GetOrders()
        {
            using var db = new NorthwindContex();
            return db.Orders.ToList();
        }

        public List<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            using var db = new NorthwindContex();
            var orderDetailsList = db.OrderDetails.Where(x => x.ProductId == id);
            foreach (var orderDetail in orderDetailsList)
            {
                orderDetail.Order = GetOrder(orderDetail.OrderId);
              
            }
            return orderDetailsList.ToList();

        }

    }
}
